// GENERATED CODE - DO NOT MODIFY BY HAND

// **************************************************************************
// InjectableConfigGenerator
// **************************************************************************

import 'package:get_it/get_it.dart' as _i1;
import 'package:injectable/injectable.dart' as _i2;
import 'package:stacked_services/stacked_services.dart' as _i3;

import '../repositories/solar_system_repository.dart' as _i4;
import '../services/event_service.dart' as _i6;
import '../views/solar_system/solar_system_viewmodel.dart' as _i5;
import '../views/start/start_viewmodel.dart' as _i7;
import 'device_info.dart' as _i8;
import 'services_module.dart' as _i9; // ignore_for_file: unnecessary_lambdas

// ignore_for_file: lines_longer_than_80_chars
/// initializes the registration of provided dependencies inside of [GetIt]
_i1.GetIt $initGetIt(_i1.GetIt get,
    {String environment, _i2.EnvironmentFilter environmentFilter}) {
  final gh = _i2.GetItHelper(get, environment, environmentFilter);
  final servicesModule = _$ServicesModule();
  gh.factory<_i3.NavigationService>(() => servicesModule.navigationSerice);
  gh.factory<_i4.SolarSystemRepository>(() => _i4.SolarSystemRepository());
  gh.factory<_i5.SolarSystemViewModel>(() => _i5.SolarSystemViewModel(
      get<_i6.EventService>(), get<_i3.NavigationService>()));
  gh.factory<_i7.StartViewModel>(() => _i7.StartViewModel(
      get<_i4.SolarSystemRepository>(), get<_i6.EventService>()));
  gh.singletonAsync<_i8.DeviceInfo>(() => _i8.DeviceInfo.instance());
  gh.singleton<_i6.EventService>(_i6.EventService());
  return get;
}

class _$ServicesModule extends _i9.ServicesModule {
  @override
  _i3.NavigationService get navigationSerice => _i3.NavigationService();
}
