using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace FlashCards
{
    class DatabaseProgram
    {
        //URI
        private static readonly string EndpointUri = "https://soft262-mobile-app.documents.azure.com:443/";
        //primary key
        private static readonly string PrimaryKey = "bK3oMHabiXqnZnrz3qSNvyV1PGI4TSaykFbNWSAUhvRiyuQh0VOgvE0Edf4F13tMDNyrNbawEODBpATGrrFw6A==";

        //Cosmos client instance
        private CosmosClient cosmosClient;
        //The database 
        private Database database;
        //The container
        private Container container;

        //Name of the database and container
        private string databaseId = "FlashcardDB";
        private string containerId = "Flashcards";
        public static async Task Main(string[] args)
        {
            //var p = new DatabaseProgram();
            //await p.Go();
        }
        public async Task CreateDB()
        {
            var p = new DatabaseProgram();
            await p.Go();
        }

        public async Task Go()
        {
            this.cosmosClient = new CosmosClient(EndpointUri, PrimaryKey, new CosmosClientOptions()
            {
                ApplicationName = "Flashcard"
            });

            //Create a new database
            this.database = await this.cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
            Console.WriteLine("Created Database: {0}\n", this.database.Id);

            //Create container
            this.container = await this.database.CreateContainerIfNotExistsAsync(containerId, "/Subject", 400);

            //Add initial records
            //await AddFlashcardIfDoesNotExist(new Flashcard("Question1", "Maths", "2+2", "4", false));
            //await AddFlashcardIfDoesNotExist(new Flashcard("Question2", "Maths", "2+3", "5", false));
            //await AddFlashcardIfDoesNotExist(new Flashcard("Question3", "Maths", "2+4", "6", false));
            //await AddFlashcardIfDoesNotExist(new Flashcard("Question4", "Science", "PH of pure water", "7", false));
            //await AddFlashcardIfDoesNotExist(new Flashcard("Question5", "Maths", "2?", "2", false));

            //Read back all records        
            //await QueryAllRecords(true);
            //await QueryAllRecords(false);

            //Update record
            //var Answered = new Flashcard("Question1", "Maths", "2+2", "4", true);
            //await ToggleAnswered("Question1", "Maths");

            //Get Question
            //await GetQuestion("Science");
            //Delete record
            //await DeleteItemAsync("Question5", "Maths");
        }

        public async Task AddFlashcardIfDoesNotExist(Flashcard p)
        {
            try
            {
                // Read the item to see if it exists.  The ID (unique) is Name property
                ItemResponse<Flashcard> Response = await this.container.ReadItemAsync<Flashcard>(p.Name, new PartitionKey(p.Topic));
                Console.WriteLine("Item in database with id: {0} already exists\n", Response.Resource.Name);
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                ItemResponse<Flashcard> Response = await this.container.CreateItemAsync<Flashcard>(p, new PartitionKey(p.Topic));

                // Note that after creating the item, we can access the body of the item with the Resource property off the ItemResponse. We can also access the RequestCharge property to see the amount of RUs consumed on this request.
                Console.WriteLine("Created item in database with id: {0} Operation consumed {1} RUs.\n", Response.Resource.Name, Response.RequestCharge);
            }
        }

        async Task QueryAllRecords(bool exp)
        {
            Console.WriteLine($"Explored is {exp}");
            var sql = $"SELECT * FROM c where c.IsAnswered = {exp.ToString().ToLower()}";
            Console.WriteLine("Running query: {0}\n", sql);
            QueryDefinition queryDefinition = new QueryDefinition(sql);
            FeedIterator<Flashcard> queryResultSetIterator = this.container.GetItemQueryIterator<Flashcard>(queryDefinition);

            List<Flashcard> cards = new List<Flashcard>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<Flashcard> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (Flashcard flashcard in currentResultSet)
                {
                    cards.Add(flashcard);
                    Console.WriteLine("\tRead {0}\n", flashcard);
                }
            }
        }

        //Update
        //async Task ToggleAnswered(string name, string sub)
        //{
          //  ItemResponse<Flashcard> resp = await this.container.ReadItemAsync<Flashcard>(name, new PartitionKey(sub.ToString()));
            //Flashcard itemBody = resp.Resource;
            //itemBody.IsAnswered = !itemBody.IsAnswered;
            ///resp = await container.ReplaceItemAsync<Flashcard>(itemBody, itemBody.Name, new PartitionKey(itemBody.Subject));
            //Console.WriteLine($"Updated {name} - answered set up {itemBody.IsAnswered} - response {resp}");
       // }

        //Delete
        private async Task DeleteItemAsync(string name, string sub)
        {
            // Delete an item. Note we must provide the partition key value and id of the item to delete
            ItemResponse<Flashcard> resp = await this.container.DeleteItemAsync<Flashcard>(name, new PartitionKey(sub.ToString()));
            Console.WriteLine($"Deleted {name} - response {resp}");
        }
        async Task GetQuestion(string sub)
        {
            Console.WriteLine("Getting a random question from subject: {0}\n", sub);
            //var sql = $"SELECT * FROM c where c.Subject = {sub.ToString()}";
            var sql = $"SELECT * FROM c";
            Console.WriteLine("Running query: {0}\n", sql);
            QueryDefinition queryDefinition = new QueryDefinition(sql);
            FeedIterator<Flashcard> queryResultSetIterator = this.container.GetItemQueryIterator<Flashcard>(queryDefinition);

            List<Flashcard> cards = new List<Flashcard>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<Flashcard> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (Flashcard flashcard in currentResultSet)
                {
                    cards.Add(flashcard);
                    Console.WriteLine("\tRead {0}\n", flashcard);
                }
            }
            List<Flashcard> cardSubject = new List<Flashcard>();
            foreach (var FC in cards)
            {
                if (FC.Topic == sub.ToString())
                {
                    cardSubject.Add(FC);
                }
            }
            Random rnd = new Random();
            int r = rnd.Next(cardSubject.Count);
            Console.WriteLine((string)cardSubject[r].Topic);
            Console.WriteLine((string)cardSubject[r].Question);
            Console.WriteLine((string)cardSubject[r].Answer);

        }

        //Delete Everything
        private async Task DeleteDatabaseAndCleanupAsync()
        {
            DatabaseResponse databaseResourceResponse = await this.database.DeleteAsync();
            // Also valid: await this.cosmosClient.Databases["FamilyDatabase"].DeleteAsync();

            Console.WriteLine("Deleted Database: {0}\n", this.databaseId);

            //Dispose of CosmosClient
            this.cosmosClient.Dispose();
        }

    }
}

