$url = 'http://localhost:4200'

cd ClientApp
(gl).path

Try
{
npm i
npm run start
}
Catch
{
}

Write-Host ('Starting ' + $url)
start $url

Write-Output 'Press Any Key ...'
Write-Host -Object ('' -f [System.Console]::ReadKey().Key.ToString());