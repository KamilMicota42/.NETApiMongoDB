using System;
using Microsoft.AspNetCore.Mvc;
using MongoExample.Services;
using MongoExample.Models;

namespace MongoExample.Controllers;

[Controller]
[Route("api/[controller]")]
public class WarehouseController: Controller{
    
    private readonly MongoDBService _MongoDBService;

    public WarehouseController(MongoDBService MongoDBService){
        _MongoDBService = MongoDBService;
    }

    [HttpGet]
    public async Task<List<Warehouse>> Get(){
        return await _MongoDBService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Warehouse warehouse){
        await _MongoDBService.CreateAsync(warehouse);
        return CreatedAtAction(nameof(Get), new{id = warehouse.Id}, warehouse);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AddToWarehouse(string id, [FromBody] string adress){
        await _MongoDBService.AddToWarehouseAsync(id, adress);
        return NoContent();
    }    //idk if i should put here (string id, [FromBody] string movieId)

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id) {
        await _MongoDBService.DeleteAsync(id);
        return NoContent();
    }
}