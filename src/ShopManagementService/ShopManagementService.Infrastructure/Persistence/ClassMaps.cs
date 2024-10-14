using Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;

namespace ShopManagementService.Infrastructure.Persistence;

public static class ClassMaps
{
    public static void RegisterClassMaps()
    {
        var pack = new ConventionPack()
        {
            /*
            *   Ustala, że nazwy elementów w dokumentach BSON będą pisane w notacji "camelCase"
            *   (np. FirstName w C# zostanie zapisane jako firstName w MongoDB).
            */
            new CamelCaseElementNameConvention(),
            /*
            *   Sprawia, że identyfikator zapisany jako ciąg znaków (string)
            *   w kodzie będzie przechowywany w bazie jako ObjectId
            */
            new StringIdStoredAsObjectIdConvention(),
            /*
             *  Sprawia, że jeśli dany element ma wartość null,
             *  to nie będzie zapisywany w dokumencie BSON.
            */
            new IgnoreIfNullConvention(true),
            /*
            *   Sprawia, że podczas deserializacji MongoDB zignoruje dodatkowe elementy
            *   w dokumencie BSON, które nie są zmapowane na właściwości w klasie C#.
            */
            new IgnoreExtraElementsConvention(true)
        };
        
        /*
         * Rejestrowanie reguł
         */
        ConventionRegistry.Register("convention", pack, t => true);

        /*
         * Mapowanie klas
         *
         * IsClassMapRegistered -> Sprawdzanie czy dana klasa jest już mapowana
         * AutoMap -> Automatyczne mapowanie właściwości danej klasy do odpowiednich pól w BSON
         * MapMember -> Określa, która właściwość będzie używała serializatora np. Id(string) -> ObjectId)
         */
        
        
        /*
         * Mapowanie klasy PRODUCT
         */
        if (!BsonClassMap.IsClassMapRegistered(typeof(Product)))
        {
            BsonClassMap.RegisterClassMap<Product>(x =>
            {
                x.AutoMap();
                x.MapMember(e => e.Id).SetSerializer(new StringSerializer(BsonType.ObjectId));
            });
        }
        
        /*
         * Mapowanie klasy Category
         */
        if (!BsonClassMap.IsClassMapRegistered(typeof(Category)))
        {
            BsonClassMap.RegisterClassMap<Category>(x =>
            {
                x.AutoMap();
                x.MapMember(e => e.Id).SetSerializer(new StringSerializer(BsonType.ObjectId));
            });
        }
        
        /*
         * Mapowanie klasy OrderItem
         */
        if (!BsonClassMap.IsClassMapRegistered(typeof(OrderItem)))
        {
            BsonClassMap.RegisterClassMap<OrderItem>(x =>
            {
                x.AutoMap();
                x.MapMember(e => e.Id).SetSerializer(new StringSerializer(BsonType.ObjectId));
            });
        }
        
        /*
         * Mapowanie klasy Order
         */
        if (!BsonClassMap.IsClassMapRegistered(typeof(Order)))
        {
            BsonClassMap.RegisterClassMap<Order>(x =>
            {
                x.AutoMap();
                x.MapMember(e => e.Id).SetSerializer(new StringSerializer(BsonType.ObjectId));
            });
        }
        
        /*
         * Mapowanie klasy Customer
         */
        if (!BsonClassMap.IsClassMapRegistered(typeof(Customer)))
        {
            BsonClassMap.RegisterClassMap<Customer>(x =>
            {
                x.AutoMap();
                x.MapMember(e => e.Id).SetSerializer(new StringSerializer(BsonType.ObjectId));
            });
        }
        
    }
}