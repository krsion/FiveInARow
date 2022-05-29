import os

PATH = 'FiveInARow'

files = ['BoardState.cs', 'Bot.cs', 'Game.cs', 'GameForm.cs', 'Program.cs']

tests = ['BoardStateTests.cs']

PATH_TESTS = 'FiveInARowTests'

size = 0

for file in files:
    size += os.path.getsize(os.path.join(PATH, file))

for file in tests:
    size += os.path.getsize(os.path.join(PATH_TESTS, file))

print(size / 1024, 'kB')