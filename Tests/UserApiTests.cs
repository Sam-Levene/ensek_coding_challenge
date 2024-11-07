using NUnit.Framework;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
using ensek_coding_challenge.Base;
using AventStack.ExtentReports;
using Newtonsoft.Json.Linq;
using System.Globalization;
using ensek_coding_challenge.Utilities;

namespace ensek_coding_challenge.Tests
{
    public class UserApiTests : ApiTestBase
    {
        private string? gasUnitOrderId;
        private string? nuclearUnitOrderId;
        private string? electricUnitOrderId;
        private string? oilUnitOrderId;

        [Test]
        public async Task AttemptToResetTheTestData()
        {
            try {
                // Act
                extentTest.Log(Status.Info, "Test Step 1: Retrieving data from the API");
                var response = await PostAsync<JObject>("/ENSEK/reset", null);
                var responseObject = new JObject();

                // Assert
                response.StatusCode.Should().Be(HttpStatusCode.OK);  // Assert status code is 200 OK
                responseObject = JsonConvert.DeserializeObject<JObject>(response.Content);   
                responseObject.Should().NotBeEmpty();  // Ensure the response is not empty
                extentTest.Log(Status.Pass, "Test Result: Passed successfully");
            } catch (Exception myException) {
                extentTest.Log(Status.Fail, "Test failed: " + myException.Message);
                throw; // re-throw the exception to mark the test as failed
            }
        }

        
        [Test]
        public async Task AttemptToBuyGasUnit()
        {
            try {
                // Act
                extentTest.Log(Status.Info, "Test Step 1: Retrieving data from the API");
                var response = await PutAsync<JObject>("/ENSEK/buy/1/1", null);
                var responseObject = new JObject();

                // Assert
                response.StatusCode.Should().Be(HttpStatusCode.OK);  // Assert status code is 200 OK
                responseObject = JsonConvert.DeserializeObject<JObject>(response.Content);  
                responseObject.Should().NotBeEmpty();  // Ensure the response is not empty
                var responseMessage = responseObject.GetValue("message").ToString();
                
                Assert.That(responseMessage.Contains("Your order id is")); // Assert the response message has a key phrase in it
                gasUnitOrderId = responseMessage.ToString().Split("Your order id is")[1];
                extentTest.Log(Status.Pass, "Test Result: Passed successfully");
            } catch (Exception myException) {
                extentTest.Log(Status.Fail, "Test failed: " + myException.Message);
                throw; // re-throw the exception to mark the test as failed
            }
        }

        [Test]
        public async Task AttemptToBuyNuclearUnit()
        {
            try {
                // Act
                extentTest.Log(Status.Info, "Test Step 1: Retrieving data from the API");
                var response = await PutAsync<JObject>("/ENSEK/buy/2/1", null);
                var responseObject = new JObject();

                // Assert
                response.StatusCode.Should().Be(HttpStatusCode.OK);  // Assert status code is 200 OK
                responseObject = JsonConvert.DeserializeObject<JObject>(response.Content);
                responseObject.Should().NotBeEmpty();  // Ensure the response is not empty
                var responseMessage = responseObject.GetValue("message").ToString();

                Assert.That(responseMessage.Contains("Your order id is")); // Assert the response message has a key phrase in it
                nuclearUnitOrderId = responseMessage.ToString().Split("Your order id is")[1];
                extentTest.Log(Status.Pass, "Test Result: Passed successfully");
            } catch (Exception myException) {
                extentTest.Log(Status.Fail, "Test failed: " + myException.Message);
                throw; // re-throw the exception to mark the test as failed
            }
        }

        [Test]
        public async Task AttemptToBuyElectricUnit()
        {
            try {
                // Act
                extentTest.Log(Status.Info, "Test Step 1: Retrieving data from the API");
                var response = await PutAsync<JObject>("/ENSEK/buy/3/1", null);
                var responseObject = new JObject();

                // Assert
                response.StatusCode.Should().Be(HttpStatusCode.OK);  // Assert status code is 200 OK
                responseObject = JsonConvert.DeserializeObject<JObject>(response.Content);
                responseObject.Should().NotBeEmpty();  // Ensure the response is not empty
                var responseMessage = responseObject.GetValue("message").ToString();

                Assert.That(responseMessage.Contains("Your order id is")); // Assert the response message has a key phrase in it
                electricUnitOrderId = responseMessage.ToString().Split("Your order id is")[1];
                extentTest.Log(Status.Pass, "Test Result: Passed successfully");
            } catch (Exception myException) {
                extentTest.Log(Status.Fail, "Test failed: " + myException.Message);
                throw; // re-throw the exception to mark the test as failed
            }
        }

        [Test]
        public async Task AttemptToBuyOilUnit()
        {
            try {
                // Act
                extentTest.Log(Status.Info, "Test Step 1: Retrieving data from the API");
                var response = await PutAsync<JObject>("/ENSEK/buy/4/1", null);
                var responseObject = new JObject();

                // Assert
                response.StatusCode.Should().Be(HttpStatusCode.OK);  // Assert status code is 200 OK
                responseObject = JsonConvert.DeserializeObject<JObject>(response.Content);
                responseObject.Should().NotBeEmpty();  // Ensure the response is not empty

                var responseMessage = responseObject.GetValue("message").ToString();
                Assert.That(responseMessage.Contains("Your order id is")); // Assert the response message has a key phrase in it
                oilUnitOrderId = responseMessage.ToString().Split("Your order id is")[1];
                extentTest.Log(Status.Pass, "Test Result: Passed successfully");
            } catch (Exception myException) {
                extentTest.Log(Status.Fail, "Test failed: " + myException.Message);
                throw; // re-throw the exception to mark the test as failed
            }
        }

        [Test]
        public async Task AttemptToGetOrderListAndConfirmOrdersPlaced()
        {
            try {
                // Act
                extentTest.Log(Status.Info, "Test Step 1: Retrieving data from the API");
                var response = await GetAsync("/ENSEK/orders");
                var responseObject = new JArray();
                int numberOfValidOrders = 0;

                // Assert
                response.StatusCode.Should().Be(HttpStatusCode.OK);  // Assert status code is 200 OK
                responseObject = JsonConvert.DeserializeObject<JArray>(response.Content);
                responseObject.Should().NotBeEmpty();  // Ensure the response is not empty

                foreach (JObject orders in responseObject) {
                    if (orders != null && orders.GetValue("id") != null) {
                    var id = orders.GetValue("id").ToString();
                        if (id == oilUnitOrderId || id == nuclearUnitOrderId || id == electricUnitOrderId || id == gasUnitOrderId) {
                            numberOfValidOrders += 1;
                        }
                    }
                }

                Assert.That(numberOfValidOrders.Equals(4)); // Assert the number of orders previously placed equals the number expected (4)
                extentTest.Log(Status.Pass, "Test Result: Passed successfully");
            } catch (Exception myException) {
                extentTest.Log(Status.Fail, "Test failed: " + myException.Message);
                throw; // re-throw the exception to mark the test as failed
            }
        }

        [Test]
        public async Task ConfirmNumberOfOrdersCreatedBeforeToday()
        {
           try {
                // Act
                extentTest.Log(Status.Info, "Test Step 1: Retrieving data from the API");
                var response = await GetAsync("/ENSEK/orders");
                var responseObject = new JArray();
                int numberOfTotalOrders = 0;
                int numberOfOrdersBeforeToday = 0;

                // Assert
                response.StatusCode.Should().Be(HttpStatusCode.OK);  // Assert status code is 200 OK
                responseObject = JsonConvert.DeserializeObject<JArray>(response.Content);
                responseObject.Should().NotBeEmpty();  // Ensure the response is not empty

                foreach (JObject orders in responseObject) {
                    numberOfTotalOrders += 1;

                    // Get the 'time' value from the JObject (in the format 'Wed, 06 Nov 2024 22:41:09 GMT')
                     string timeString = orders.GetValue("time").ToString();

                    // Define the format string for RFC 1123 date-time format
                    string format = "ddd, dd MMM yyyy HH:mm:ss GMT";

                    // Parse the string into DateTime
                    DateTime dateTime = DateTime.ParseExact(timeString, format, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
                    
                    if(dateTime.Date < HelperFunctions.getCurrentDate().Date) {
                        numberOfOrdersBeforeToday += 1;
                    }

                    // Assert the total number of orders placed before today is 4 less than the current total number of orders
                    Assert.That((numberOfOrdersBeforeToday + 4).Equals(numberOfTotalOrders));
                }
                extentTest.Log(Status.Pass, "Test Result: Passed successfully");
            } catch (Exception myException) {
                extentTest.Log(Status.Fail, "Test failed: " + myException.Message);
                throw; // re-throw the exception to mark the test as failed
            }
        }
    }
}
