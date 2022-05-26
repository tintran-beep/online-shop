Add-Migration Initial -Context CoreDbContext -OutputDir Core\MigrationHistory
Update-Database -Context CoreDbContext