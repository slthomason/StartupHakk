//Nethereum
using Nethereum.Web3;

var web3 = new Web3("http://localhost:8545");
var balance = await web3.Eth.GetBalance.SendRequestAsync("0x6a1c6e2d6b50c6b52a6a32c6e42a8e1d6a8115f5");
Console.WriteLine($"Balance: {balance}");





//CardanoSharp

using CardanoSharp;
using CardanoSharp.Wallet;
using CardanoSharp.Wallet.Models.Transactions;
using System;
using System.Threading.Tasks;

namespace CardanoSharpExample
{
   public class Program
    {
        public static async Task Main(string[] args)
        {
            var nodeUrl = "https://cardano-node-url.com"; // Replace with the URL of your Cardano node
            var cardanoSharp = new CardanoSharp(nodeUrl);

            var blockHeight = await cardanoSharp.GetBlockchainHeight();
            Console.WriteLine("Current Cardano blockchain height: " + blockHeight);
        }
    }
}



//BlockM3
using BlockM3;
using BlockM3.AES;
using BlockM3.BlockChain;
using BlockM3.Cryptography;
using BlockM3.Validators;

// Generate a Bitcoin address
BitcoinAddressGenerator generator = new BitcoinAddressGenerator();
string privateKey = "examplePrivateKey";
string publicKey = generator.GeneratePublicAddress(privateKey);
Console.WriteLine("Public Address: " + publicKey);


//Neo

using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;

public class HelloWorld : SmartContract
{
    public static void Main(string message)
    {
        Storage.Put(Storage.CurrentContext, "Hello", message);
    }
}






//Stratis
using System;
using System.Threading.Tasks;
using Stratis.Bitcoin.Features.BlockStore;
using Stratis.Bitcoin.Features.RPC;
using Stratis.Bitcoin.Features.SmartContracts;
using Stratis.Bitcoin.Features.SmartContracts.Networks;
using Stratis.Bitcoin.Features.Wallet;
using Stratis.Bitcoin.Networks;
using Stratis.Bitcoin.Tests.Common;
using Stratis.SmartContracts;

class Program
{
    static async Task Main(string[] args)
    {
        var network = new SmartContractsRegTest();
        var builder = NodeBuilder.Create(network);
        var node = builder.CreateSmartContractNode();
        node.NotInIBD();

        await node.StartAsync();

        // interact with the node here

        await node.StopAsync();
    }
}

using Stratis.SmartContracts;

public class StorageContract : SmartContract
{
    public StorageContract(ISmartContractState smartContractState) : base(smartContractState)
    {
    }

    public void SetValue(string value)
    {
        PersistentState.SetString("Value", value);
    }

    public string GetValue()
    {
        return PersistentState.GetString("Value");
    }
}









//Blockfrost
using Blockfrost.Api;

public class SimpleApp
{
    private readonly BlockfrostClient client;

    public SimpleApp()
    {
        client = new BlockfrostClient("YOUR_API_KEY");
    }

    public async Task<BlockResponse> GetLatestBlock()
    {
        var block = await client.BlocksLatestAsync();
        return block;
    }
}











//Nethermind
using Nethermind.Core;
using Nethermind.Core.JsonRpc;
using Nethermind.Core.Web3;

public class SimpleApp
{
    private readonly IJsonRpcClient rpcClient;

    public SimpleApp()
    {
        rpcClient = new JsonRpcClient("http://localhost:8545");
    }

    public async Task<Wei> GetAccountBalance(string address)
    {
        var web3 = new Web3(rpcClient);
        var balance = await web3.Eth.GetBalance(address);
        return balance;
    }
}