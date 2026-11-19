# StorageApi

## Efter Scaffold

Undersök koden som har skapats:

Vilka metoder har genererats?

* Klassen `ProductsController` har genererats med metoderna
    `GetProduct()`,
    `GetProduct(int id)`,
    `PutProduct(int? id, Product product)`,
    `PostProduct(Product product)` och
    `DeleteProduct(int? id)`
    för att hantera API-anrop,
    samt hjälpmetoden `ProductExists(int? id)`.

Hur används `StorageContext`?

* Den används för att få tillgång till produkt-objekten via `_context.Product`,
  för att ange uppdaterade produkt-objekt via `_context.Entry(product)`
  och för att spara ändringarna till databasen via
  `_context.SaveChangesAsync()`.

Hur fungerar `CreatedAtAction`, `Ok`, `NotFound` osv?

* De skapar svar på API-anrop med olika status. `CreatedAtAction` sätter också en svars-body.
