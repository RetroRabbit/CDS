#EXAMPLE Add-Migration IAddedSomeTales

Steps

Initial Creation
1. Delete Database
2. Add-Migration Initial
3. Update-Database

Making Changes to Entities
1. Make Changes to Entities
2. Add-Migration ChangedEntities
3. Update-Database

Adding new Entities
1. Add New Entity
2. Add to AuthContext
3. Add-Migration AddedEntities
4. Update-Database

After Every change run Add-Migration [Migration Name] then run Update-Database