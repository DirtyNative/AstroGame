// GENERATED CODE - DO NOT MODIFY BY HAND

// **************************************************************************
// InjectableConfigGenerator
// **************************************************************************

import 'package:get_it/get_it.dart' as _i1;
import 'package:injectable/injectable.dart' as _i2;

import '../services/event_service.dart' as _i4;
import '../views/planet/planet_viewmodel.dart' as _i3;
import 'device_info.dart' as _i5; // ignore_for_file: unnecessary_lambdas

// ignore_for_file: lines_longer_than_80_chars
/// initializes the registration of provided dependencies inside of [GetIt]
_i1.GetIt $initGetIt(_i1.GetIt get,
    {String environment, _i2.EnvironmentFilter environmentFilter}) {
  final gh = _i2.GetItHelper(get, environment, environmentFilter);
  gh.factory<_i3.PlanetViewModel>(
      () => _i3.PlanetViewModel(get<_i4.EventService>()));
  gh.singletonAsync<_i5.DeviceInfo>(() => _i5.DeviceInfo.instance());
  gh.singleton<_i4.EventService>(_i4.EventService());
  return get;
}
