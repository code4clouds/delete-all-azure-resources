using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

class Program
{
    static async Task Main(string[] args)
    {
        // Prompt the user to enter the subscription ID
        Console.Write("Enter your Azure subscription ID: ");
        string subscriptionId = Console.ReadLine();

        // Authenticate using interactive browser authentication
        var credential = new InteractiveBrowserCredential();

        // Initialize the Resource Management Client
        ArmClient armClient = new ArmClient(credential, subscriptionId);

        // Retrieve all resource groups in the subscription
        SubscriptionResource subscription = armClient.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{subscriptionId}"));
        await foreach (ResourceGroupResource resourceGroup in subscription.GetResourceGroups().GetAllAsync())
        {
            Console.WriteLine(resourceGroup.Data.Name);
        }

        // Ask for user confirmation
        Console.Write("Are you sure you want to delete all these resource groups? (yes/no): ");
        string confirmation = Console.ReadLine();

        if (confirmation.Equals("yes", StringComparison.OrdinalIgnoreCase))
        {
            await foreach (ResourceGroupResource resourceGroup in subscription.GetResourceGroups().GetAllAsync())
            {
                string rgName = resourceGroup.Data.Name;
                Console.WriteLine($"Deleting resource group: {rgName}");

                // Delete the resource group
                await resourceGroup.DeleteAsync(WaitUntil.Completed);

                Console.WriteLine($"Deleted resource group: {rgName}");
            }

            Console.WriteLine("All resource groups have been deleted.");
        }
        else
        {
            Console.WriteLine("Operation canceled by user.");
        }
    }
}
