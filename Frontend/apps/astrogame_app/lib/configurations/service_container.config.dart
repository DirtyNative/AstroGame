// GENERATED CODE - DO NOT MODIFY BY HAND

// **************************************************************************
// InjectableConfigGenerator
// **************************************************************************

import 'package:get_it/get_it.dart' as _i1;
import 'package:injectable/injectable.dart' as _i2;

import '../repositories/solar_system_repository.dart' as _i4;
import '../services/event_service.dart' as _i7;
import '../views/planet/planet_viewmodel.dart' as _i3;
import '../views/start/start_viewmodel.dart' as _i5;
import 'device_info.dart' as _i6; // ignore_for_file: unnecessary_lambdas

// ignore_for_file: lines_longer_than_80_chars
/// initializes the registration of provided dependencies inside of [GetIt]
_i1.GetIt $initGetIt(_i1.GetIt get,
    {String environment, _i2.EnvironmentFilter environmentFilter}) {
  final gh = _i2.GetItHelper(get, environment, environmentFilter);
  gh.factory<_i3.PlanetViewModel>(() => _i3.PlanetViewModel());
  gh.factory<_i4.SolarSystemRepository>(() => _i4.SolarSystemRepository());
  gh.factory<_i5.StartViewModel>(
      () => _i5.StartViewModel(get<_i4.SolarSystemRepository>()));
  gh.singletonAsync<_i6.DeviceInfo>(() => _i6.DeviceInfo.instance());
  gh.singleton<_i7.EventService>(_i7.EventService());
  return get;
}
