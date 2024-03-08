. ./utils.ps1

if (-not (Test-Path .venv))
{
	Write-Host "Installing venv"
	python -m venv .venv
}

ActivateVenv

Write-Host "Installing deps"
pip install -r .\requirements.txt