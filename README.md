You can run multiplle accounts and  teleport (across servers for example dungeon quest and anime defenders will work) using this script

How this works:
a filestream is created to robloxcookie.dat this causes error 773 to not occour (idk why it just does)
after that we are check if RobloxPlayerInstaller(.exe) exists and delete it to prevent that bug from occouring
finally we create a mutex to allow multiple clients at once and wait for a key input and whenever that happends the program stops

i hereby grant anyone to distribute, edit and use the script as pleased and feel free to reach out to me or make a PR 
