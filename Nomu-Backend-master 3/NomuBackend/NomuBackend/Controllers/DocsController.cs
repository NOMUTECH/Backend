using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using NomuBackend.Model;

namespace NomuBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocsController : ControllerBase
    {
        private readonly IMongoDatabase _database;

        public DocsController(IMongoDatabase database)
        {
            _database = database;
        }

        [HttpPost]
        public IActionResult CreateDoc([FromBody] Docs doc)
        {
            var collection = _database.GetCollection<Docs>("Docs");
            collection.InsertOne(doc);
            return CreatedAtAction(nameof(GetDocById), new { docId = doc.DocId }, doc);
        }

        [HttpGet("{docId}")]
        public IActionResult GetDocById(string docId)
        {
            var collection = _database.GetCollection<Docs>("Docs");
            var doc = collection.Find(d => d.DocId == docId).FirstOrDefault();
            if (doc == null)
                return NotFound();
            return Ok(doc);
        }

        [HttpPut("{docId}")]
        public IActionResult UpdateDoc(string docId, [FromBody] Docs updatedDoc)
        {
            var collection = _database.GetCollection<Docs>("Docs");
            var filter = Builders<Docs>.Filter.Eq(d => d.DocId, docId);
            var update = Builders<Docs>.Update
                            .Set(d => d.DocType, updatedDoc.DocType)
                            .Set(d => d.DocContent, updatedDoc.DocContent)
                            .Set(d => d.ProductCatalogue, updatedDoc.ProductCatalogue)
                            .Set(d => d.StaffInfo, updatedDoc.StaffInfo)
                            .Set(d => d.ContactInfo, updatedDoc.ContactInfo);

            var result = collection.UpdateOne(filter, update);
            if (result.MatchedCount == 0)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{docId}")]
        public IActionResult DeleteDoc(string docId)
        {
            var collection = _database.GetCollection<Docs>("Docs");
            var result = collection.DeleteOne(d => d.DocId == docId);
            if (result.DeletedCount == 0)
                return NotFound();
            return NoContent();
        }
    }
}
