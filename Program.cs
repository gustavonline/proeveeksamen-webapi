using proeveeksamen_webapi.Models;

var builder = WebApplication.CreateBuilder(args);

// add swagger
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

//create list of customer and add data
List<Customer> customers = new List<Customer>();
customers.Add(new Customer(){Id = 1, Name = "John Doe", email = "johndoe@email.com", type = "business"});
customers.Add(new Customer(){Id = 2, Name = "Jane Doe", email = "janedoe@email.com", type = "private"});
customers.Add(new Customer(){Id = 3, Name = "John Smith", email = "johnsmith@email.com", type = "business"});
customers.Add(new Customer(){Id = 4, Name = "Jane Smith", email = "janesmith@email.com",type ="private"});

// api start-up message on root
app.MapGet("/", () => "api is running!");

// GET: all customers
app.MapGet("/api/kunder", () => customers);

// GET: customer by id
app.MapGet("/api/kunder/{id}", (int id) => customers.Where(c => c.Id == id).FirstOrDefault());

// POST: create new customer
app.MapPost("/api/kunder", (Customer customer) => {
    customers.Add(customer);
    return customer;
});

// DELETE: delete customer by id
app.MapDelete("/api/kunder/{id}", (int id) => {
    var customer = customers.Where(c => c.Id == id).FirstOrDefault();
    customers.Remove(customer);
    return customer;
});

// GET: customers emails by type
app.MapGet("/api/kunder/emails/{type}", (string type) => {
    var emails = customers.Where(c => c.type == type).Select(c => c.email).ToList();
    return emails;
});

app.Run();
