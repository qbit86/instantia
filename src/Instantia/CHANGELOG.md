# Changelog

## [Unreleased] - 2021-11-21
### Changed
- Dropped support of `netcoreapp2.1` in favor of `netcoreapp3.1`.

## [0.3.0] - 2019-07-09
### Fixed
- `UnixEpoch` field is now of type `UtcDateTime`, not `DateTime`.

## [0.2.0] - 2019-07-09
### Added
- `FromDateTimeOffset()` static method.
- `GetCurrent()` static method as an alternative to `UtcNow` static property.
### Removed
- `Today` static property.

## [0.1.0] - 2019-06-30
### Added
- `UtcDateTime` type.

[Unreleased]: https://github.com/qbit86/instantia/compare/instantia-0.3.0...HEAD
[0.3.0]: https://github.com/qbit86/instantia/compare/instantia-0.2.0...instantia-0.3.0
[0.2.0]: https://github.com/qbit86/instantia/compare/instantia-0.1.0...instantia-0.2.0
[0.1.0]: https://github.com/qbit86/instantia/releases/tag/instantia-0.1.0
