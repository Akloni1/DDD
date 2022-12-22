// See https://aka.ms/new-console-template for more information
using DDD.Data;
using DDD.Factory;
using DDD.Models;
using DDD.Repository.BuyerRepository;

Console.WriteLine("Hello, World!");
IBuyer buyer = FactoryBuyer.CreateBuyer("Покупатель");

IBuyerRepository buyerRepository = new BuyerRepository(new DDDContext());
buyerRepository.AddBuyer(buyer, new BuyerRoot() { Gender = "Муж" });