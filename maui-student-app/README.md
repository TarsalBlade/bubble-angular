# SAMS Mobile (.NET MAUI)

Copy this folder into a new MAUI solution, then run:

```bash
dotnet restore
dotnet build
```

## Replace these values

In `Services/SupabaseService.cs`, set:

- `SupabaseUrl`
- `SupabaseAnonKey`

## Flow

1. Student logs in on `LoginPage`.
2. `AuthService` maps the Supabase auth user to the `students` table by `auth_user_id`.
3. Home screen loads attendance for that student only.
4. Teacher features stay on your existing web app.
