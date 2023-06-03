For a list of known issues go to the [Known Issues][known-issues-url]
page on the [_**Start Page+**_ (64-bit)][start-page-plus-64-bit-url] website.

Microsoft didn't make it easy to have a 32-bit & 64-bit extension be able to be
**_written once and run in both_**, so this new 64-bit version will ONLY run in 
**VS 2022 or higher**.

To use _**Start Page+ 1.x**_ in VSS 2017 or 2019, plese refer to 
the original [_**Start Page+**_ (32-bit)][start-page-plus-32-bit-url] website.

[start-page-plus-64-bit-url]: https://luminous-software.solutions/start-page-plus-64-bit
[start-page-plus-32-bit-url]: https://luminous-software.solutions/start-page-plus
[known-issues-url]: https://luminous-software.solutions/start-page-plus-64-bit/known-issues

## Releases

### v0.22 - 2023-06-03

#### Bug Fixes
- Saving a list's settings requires a _manual_ refresh [#28][#28]

[#28]: https://github.com/luminous-software/start-page-plus-64-bit/issues/28
[p12]: https://github.com/yannduran/start-page-plus-64-bit/issues/12

- Some start items don't refresh the **Recent Items** list [#29][#29]

[#29]: https://github.com/luminous-software/start-page-plus-64-bit/issues/29
[p11]: https://github.com/yannduran/start-page-plus-64-bit/issues/11

- After closing a solution, the **Recent Items** list is not refreshed [#33][#33]

[#33]: https://github.com/luminous-software/start-page-plus-64-bit/issues/33
[p15]: https://github.com/yannduran/start-page-plus-64-bit/issues/15

- Saving a list's settings causes the first item to appear _selected_
	- normally list items do not stay _selected_, even after clicking them

[p17]: https://github.com/yannduran/start-page-plus-64-bit/issues/17

#### New Features
- Setting to show the **News Items** pane (default=true) [#2][#02]

[#02]: https://github.com/luminous-software/start-page-plus-64-bit/issues/2
[p07]: https://github.com/yannduran/start-page-plus-64-bit/issues/7

- Tooltips in the **News Items** list [#16][#16]

[#16]: https://github.com/luminous-software/start-page-plus-64-bit/issues/16
[p09]: https://github.com/yannduran/start-page-plus-64-bit/issues/9

- In the **Start Items** pane, the **Options** button has been renamed to **Settings**
	- now opens the the **Start Items** tab in settings
	- instead of the **General** tab

[p16]: https://github.com/yannduran/start-page-plus-64-bit/issues/16

#### Contributions
- thanks to @MagicAndre1981 for his pull request

### v0.21 - 2023-05-07

#### Bug Fixes
- Incorrect wording for the **Restart Visual Studio** start item

[p03]: https://github.com/yannduran/start-page-plus-64-bit/issues/3

- In the **Recent Items** pane, the **Settings** button goes to the **General** tab
instead of the **Recent Items** tab

[p02]: https://github.com/yannduran/start-page-plus-64-bit/issues/2

#### New Features
- Setting to hide _**Start Page+**_ on solution load (default=false) [#5][#05]

[#05]: https://github.com/luminous-software/start-page-plus-64-bit/issues/5
[p06]: https://github.com/yannduran/start-page-plus-64-bit/issues/6

- Setting to show _**Start Page+**_ on solution close (default=false) [#5][#05]

- Auto-refresh the **Recent Items** list after closing a solution [#13][#13]

[#13]: (https://github.com/luminous-software/start-page-plus-64-bit/issues/13)
[p05]: https://github.com/yannduran/start-page-plus-64-bit/issues/5

- Setting to show `csproj` files in the **Recent Items** list (default=true) [#15][#15]

[#15]: https://github.com/luminous-software/start-page-plus-64-bit/issues/15
[p08]: https://github.com/yannduran/start-page-plus-64-bit/issues/8

- Group settings into **Appearance** & **Behavior** sections [#30][#30]

[#30]: https://github.com/luminous-software/start-page-plus-64-bit/issues/30
[p13]: https://github.com/yannduran/start-page-plus-64-bit/issues/13

### v0.20 - 2023-04-27

#### Bug Fixes
- Fix `NullReferenceException` in `LoadAsync()` [#1][#01]

[#01]: https://github.com/luminous-software/start-page-plus-64-bit/issues/1

- **Recent Items** list shows no paths, only project names [#6][#06]

[#06]: https://github.com/luminous-software/start-page-plus-64-bit/issues/6

- Downgrade the **Community VS Toolkit** NuGet Packages [#11][#11]

[#11]: https://github.com/luminous-software/start-page-plus-64-bit/pull/11

#### New Features
- arm64 support [#8][#08]

[#08]: https://github.com/luminous-software/start-page-plus-64-bit/pull/8

#### Contributions
- thanks to @MagicAndre1981 for his 3 pull requests

### v0.19 - 2023-04-21
- first public preview of basic functionality