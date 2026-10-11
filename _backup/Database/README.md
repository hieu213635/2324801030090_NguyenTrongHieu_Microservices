# PostgreSQL backups

These are plain-text SQL dumps of the project's four PostgreSQL databases:

- `lab_netmicro_payments.sql`
- `lab_netmicro_jobs.sql`
- `lab_netmicro_policy.sql`
- `lab_netmicro_pricing.sql`

Custom-format PostgreSQL archives are also included for use with `pg_restore`:

- `lab_netmicro_payments.backup`
- `lab_netmicro_jobs.backup`
- `lab_netmicro_policy.backup`
- `lab_netmicro_pricing.backup`

The databases were empty when backed up: the project currently initializes these
database names and the `lab_user` role, but no application tables or rows were
present in PostgreSQL. Each dump can be restored independently.

## Restore on Windows

Run these commands from the repository root in PowerShell, with PostgreSQL's
`psql` command-line tools available and the PostgreSQL server running. The first
command creates the role and databases; run it only on a fresh database server.

```powershell
psql -U postgres -d postgres -v ON_ERROR_STOP=1 -f .\postgres\createdatabases.sql
psql -U postgres -d lab_netmicro_payments -v ON_ERROR_STOP=1 -f .\_backup\Database\lab_netmicro_payments.sql
psql -U postgres -d lab_netmicro_jobs -v ON_ERROR_STOP=1 -f .\_backup\Database\lab_netmicro_jobs.sql
psql -U postgres -d lab_netmicro_policy -v ON_ERROR_STOP=1 -f .\_backup\Database\lab_netmicro_policy.sql
psql -U postgres -d lab_netmicro_pricing -v ON_ERROR_STOP=1 -f .\_backup\Database\lab_netmicro_pricing.sql
```

`psql` prompts for the PostgreSQL administrator password if required. To check
that the databases were created, run:

```powershell
psql -U postgres -d postgres -c "SELECT datname FROM pg_database WHERE datname LIKE 'lab_netmicro_%' ORDER BY datname;"
```

## Restore custom-format `.backup` files

Create the role and databases first using `postgres\createdatabases.sql` as
shown above. Then restore each archive with PostgreSQL's `pg_restore` tool:

```powershell
pg_restore -U postgres -d lab_netmicro_payments .\_backup\Database\lab_netmicro_payments.backup
pg_restore -U postgres -d lab_netmicro_jobs .\_backup\Database\lab_netmicro_jobs.backup
pg_restore -U postgres -d lab_netmicro_policy .\_backup\Database\lab_netmicro_policy.backup
pg_restore -U postgres -d lab_netmicro_pricing .\_backup\Database\lab_netmicro_pricing.backup
```
