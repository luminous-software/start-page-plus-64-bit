For a list of known issues go to the [Known Issues][known-issues-url]
page on the [Start Page+ (64-bit)][start-page-plus-64-bit-url] website.

Microsoft didn't make it easy to have a 32-bit & 64-bit extension be able to be
**_written once and run in both_**, so this new 64-bit version will ONLY run in 
**VS 2022 or higher**.

To use *Start Page+ 1.x* in VSS 2017 or 2019, plese refer to 
the original [Start Page+ (32-bit)][start-page-plus-32-bit-url] website.

[start-page-plus-64-bit-url]: https://luminous-software.solutions/start-page-plus-64-bit
[start-page-plus-32-bit-url]: https://luminous-software.solutions/start-page-plus
[known-issues-url]: https://luminous-software.solutions/start-page-plus-64-bit/known-issues

## Releases

### v0.21 - 2023-04-??

#### Bug Fixes
- Incorrect wording for Restart Visual Studio start item

	[private issue #3]: https://github.com/yannduran/start-page-plus-64-bit/issues/3

- Recent Items 'Settings' button goes to 'General' instead of 'Recent Items'

	[private issue #2]: https://github.com/yannduran/start-page-plus-64-bit/issues/2

#### New Features
- Hide StartPage+ on solution load (including option, default=false) [[#5](https://github.com/luminous-software/start-page-plus-64-bit/issues/5)]

	[private issue #6]: https://github.com/yannduran/start-page-plus-64-bit/issues/6

- Show StartPage+ on solution close (including option, default=false) [[#5](https://github.com/luminous-software/start-page-plus-64-bit/issues/5)]

	[private issue #6]: https://github.com/yannduran/start-page-plus-64-bit/issues/6

- After closing a solution refresh the Recent items [[#13](https://github.com/luminous-software/start-page-plus-64-bit/issues/5)]

	[private issue #5]: https://github.com/yannduran/start-page-plus-64-bit/issues/5

- Option to show/hide csproj files in Recent Items list (default=true) [[#15](https://github.com/luminous-software/start-page-plus-64-bit/issues/15)]

	[private issue #8]: https://github.com/yannduran/start-page-plus-64-bit/issues/8

- Group settings/options into 'Appearance' & 'Behavior'[[#30](https://github.com/luminous-software/start-page-plus-64-bit/issues/30)]

	[private issue #13]: https://github.com/yannduran/start-page-plus-64-bit/issues/13

### v0.20 - 2023-04-27

#### Bug Fixes
- NullReferenceException in LoadAsync() ([#1](https://github.com/luminous-software/start-page-plus-64-bit/issues/1))

- Recent list shows no path, only project name ([#6](https://github.com/luminous-software/start-page-plus-64-bit/issues/6))

- Downgrade Community Toolkit NuGet Packages ([#10](https://github.com/luminous-software/start-page-plus-64-bit/pull/11))

#### New Features
- arm64 support ([#8](https://github.com/luminous-software/start-page-plus-64-bit/pull/8))

#### Contributions
- thanks to @MagicAndre1981 for his 3 pull requests

### v0.19 - 2023-04-21
- first public release