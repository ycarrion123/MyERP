# CreateFolders.ps1
# Este script crea la estructura de carpetas para el proyecto MyERP (en la carpeta donde está el .csproj)

# Ruta base: Ajusta la ruta EXACTA donde está tu .csproj
$project = "C:\Users\Yelser Carrion\source\repos\MyERP\MyERP\MyERP"

# Crear carpetas para Models
$modelsFolders = @(
    (Join-Path $project "Models"),
    (Join-Path $project "Models\Identity"),
    (Join-Path $project "Models\Account"),
    (Join-Path $project "Models\SaaS")
)
foreach ($folder in $modelsFolders) {
    New-Item -ItemType Directory -Force -Path $folder | Out-Null
}

# Crear carpetas para Services
$servicesFolders = @(
    (Join-Path $project "Services"),
    (Join-Path $project "Services\Interfaces"),
    (Join-Path $project "Services\Repositories"),
    (Join-Path $project "Services\Identity"),
    (Join-Path $project "Services\Account"),
    (Join-Path $project "Services\SaaS"),
    (Join-Path $project "Services\Integration")
)
foreach ($folder in $servicesFolders) {
    New-Item -ItemType Directory -Force -Path $folder | Out-Null
}

# Crear carpetas para ViewModels y Views
New-Item -ItemType Directory -Force -Path (Join-Path $project "ViewModels") | Out-Null
New-Item -ItemType Directory -Force -Path (Join-Path $project "Views") | Out-Null

Write-Output "La estructura de carpetas se ha creado correctamente."
