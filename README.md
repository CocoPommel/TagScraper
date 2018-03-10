# TagScraper
Checks a .txt of derpicdn.net links for a certain tag, then writes all links containing the tag to a seperate .txt.

## Use
Before running, make sure text file containing collection in the same directory as the .exe, as well as a text file containing any strings to filter from the output. **Only the TagScraper folder is required to run, not the code in the main folider.**

Example: grabbing all Storm King pictures from others that aren't in the storm king collection. Assumes stormking.txt has already been filled with all links in the collection and others.txt contains all strings in others.
>Enter name of text file with derpicdn links:
```
others
```
>Enter tag to search for:
```
storm king
```
>Enter any key to start. Alternatively, if you want to strip certain strings from output, enter name of text file containing strings to ignore:
```
stormking
```

Example 2: grabbing all Tirek pictures from others, under the same assumptions
>Enter name of text file with derpicdn links:
```
others
```
>Enter tag to search for:
```
lord tirek
```
>Enter any key to start. Alternatively, if you want to strip certain strings from output, enter name of text file containing strings to ignore:
```
s
```
