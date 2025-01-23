using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Authorize]
public class CustomerController : Controller {
    private readonly MyDbContext _context;

    public CustomerController(MyDbContext context) {
        _context = context;
    }

    // GET: Customer
    // public async Task<IActionResult> Index() {
    //     var customers = await _context.customers
    //         .Include(c => c.customer_addresses)
    //         .ThenInclude(ca => ca.address)
    //         .ThenInclude(a => a.country)
    //         .Include(c => c.cust_orders)
    //         .ToListAsync();
    //     
    //     return View(customers);
    // }

    public async Task<IActionResult> Index(int page = 1, int size = 20) {
        var totalRecords = await _context.Customers.CountAsync();
        var customers = await _context
            .Customers
            .Include(c => c.customer_addresses)
            .ThenInclude(ca => ca.Address)
            .ThenInclude(a => a.Country)
            .Include(c => c.cust_orders)
            .OrderBy(e => e.customer_id)
            .Skip((page - 1) * size)
            .Take(size)
            .AsNoTracking()
            .ToListAsync();

        ViewBag.CurrentPage = page;
        ViewBag.TotalPages = (int)Math.Ceiling(totalRecords / (double)size);
        ViewBag.PageSize = size;

        return View(customers);
    }

    // GET: Customer/Details/5
    public async Task<IActionResult> Details(int? id) {
        if (id == null) {
            return NotFound();
        }

        var customer = await _context.Customers
            .FirstOrDefaultAsync(m => m.customer_id == id);
        if (customer == null) {
            return NotFound();
        }

        return View(customer);
    }

    // GET: Customer/Create
    public IActionResult Create() {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("customer_id,first_name,last_name,email,country")] Customer customer)
    {
        if (ModelState.IsValid)
        {
            var maxCustomerId = await _context.Customers
                .OrderByDescending(c => c.customer_id)
                .Select(c => c.customer_id)
                .FirstOrDefaultAsync();

            customer.customer_id = maxCustomerId + 1;

            _context.Add(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(customer);
    }


    public async Task<IActionResult> Edit(int? id) {
        if (id == null) {
            return NotFound();
        }

        var customer = await _context.Customers.FindAsync(id);
        if (customer == null) {
            return NotFound();
        }

        return View(customer);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,
        [Bind("customer_id,first_name,last_name,email,country")]
        Customer customer) {
        if (id != customer.customer_id) {
            return NotFound();
        }

        if (ModelState.IsValid) {
            try {
                _context.Update(customer);
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!CustomerExists(customer.customer_id)) {
                    return NotFound();
                }

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(customer);
    }

    public async Task<IActionResult> Delete(int? id) {
        if (id == null) {
            return NotFound();
        }

        var customer = await _context.Customers
            .FirstOrDefaultAsync(m => m.customer_id == id);
        if (customer == null) {
            return NotFound();
        }

        return View(customer);
    }

    public async Task<IActionResult> Orders(int? id) {
        if (id == null) {
            return NotFound();
        }

        var orders = await _context.CustOrders
            .Where(o => o.CustomerId == id)
            .ToListAsync();

        if (orders == null) {
            return NotFound();
        }

        return View(orders);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) {
        var customer = await _context.Customers.FindAsync(id);
        if (customer != null) {
            _context.Customers.Remove(customer);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CustomerExists(int id) {
        return _context.Customers.Any(e => e.customer_id == id);
    }

    public async Task<IActionResult> CustomerOrders(int id)
    {
        var orders = await _context.CustOrders
            .Include(o => o.ShippingMethod)
            .Where(o => o.CustomerId == id)
            .ToListAsync();

        if (orders == null || !orders.Any())
        {
            return NotFound("No orders found for this customer.");
        }

        return View(orders); 
    }
    
    public async Task<IActionResult> OrderDetails(int id)
    {
        var order = await _context.CustOrders
            .Include(o => o.OrderHistories)
            .FirstOrDefaultAsync(o => o.OrderId == id);

        if (order == null)
        {
            return NotFound("Order not found.");
        }

        return View(order);
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateStatus(int order_id, int new_status)
    {
        var order = await _context.CustOrders
            .Include(o => o.OrderHistories)
            .FirstOrDefaultAsync(o => o.OrderId == order_id);

        if (order == null)
        {
            return NotFound("Order not found.");
        }

        var currentStatus = order.OrderHistories
            .OrderByDescending(h => h.StatusDate)
            .FirstOrDefault()?.StatusId ?? 0;

        if (currentStatus >= 4)
        {
            return BadRequest("Cannot update status. Current status is 4 or higher.");
        }

        var history = new OrderHistory
        {
            OrderId = order_id,
            StatusId = new_status,
            StatusDate = DateTime.Now
        };

        _context.OrderHistories.Add(history);
        
        return RedirectToAction("Index");
    }
}