// GENERATED CODE - DO NOT MODIFY BY HAND

// **************************************************************************
// InjectableConfigGenerator
// **************************************************************************

import 'package:dio/dio.dart' as _i10;
import 'package:get_it/get_it.dart' as _i1;
import 'package:injectable/injectable.dart' as _i2;
import 'package:stacked_services/stacked_services.dart' as _i6;

import '../communications/interceptors/header_interceptor.dart' as _i3;
import '../communications/repositories/authorization_repository.dart' as _i13;
import '../communications/repositories/player_repository.dart' as _i11;
import '../communications/repositories/solar_system_repository.dart' as _i12;
import '../executers/fetch_solar_system_executer.dart' as _i14;
import '../executers/login_executer.dart' as _i16;
import '../helpers/dialog_helper.dart' as _i15;
import '../providers/authorization_token_provider.dart' as _i5;
import '../providers/http_header_provider.dart' as _i4;
import '../providers/player_provider.dart' as _i17;
import '../services/event_service.dart' as _i8;
import '../views/login/login_viewmodel.dart' as _i18;
import '../views/solar_system/solar_system_viewmodel.dart' as _i7;
import '../views/species_selection/species_selection_viewmodel.dart' as _i9;
import '../views/start/start_viewmodel.dart' as _i19;
import 'device_info.dart' as _i20;
import 'services_module.dart' as _i21; // ignore_for_file: unnecessary_lambdas

// ignore_for_file: lines_longer_than_80_chars
/// initializes the registration of provided dependencies inside of [GetIt]
_i1.GetIt $initGetIt(_i1.GetIt get,
    {String environment, _i2.EnvironmentFilter environmentFilter}) {
  final gh = _i2.GetItHelper(get, environment, environmentFilter);
  final servicesModule = _$ServicesModule();
  gh.lazySingleton<_i3.HeaderInterceptor>(() => _i3.HeaderInterceptor());
  gh.factory<_i4.HttpHeaderProvider>(
      () => _i4.HttpHeaderProvider(get<_i5.AuthorizationTokenProvider>()));
  gh.lazySingleton<_i6.NavigationService>(
      () => servicesModule.navigationService);
  gh.factory<_i7.SolarSystemViewModel>(() => _i7.SolarSystemViewModel(
      get<_i8.EventService>(), get<_i6.NavigationService>()));
  gh.factory<_i9.SpeciesSelectionViewModel>(
      () => _i9.SpeciesSelectionViewModel());
  gh.factory<_i10.Dio>(() => servicesModule.dio(get<_i3.HeaderInterceptor>()));
  gh.factory<_i11.PlayerRepository>(
      () => _i11.PlayerRepository(get<_i10.Dio>()));
  gh.factory<_i12.SolarSystemRepository>(
      () => _i12.SolarSystemRepository(get<_i10.Dio>()));
  gh.factory<_i13.AuthorizationRepository>(
      () => _i13.AuthorizationRepository(get<_i10.Dio>()));
  gh.factory<_i14.FetchSolarSystemExecuter>(() => _i14.FetchSolarSystemExecuter(
      get<_i15.DialogHelper>(), get<_i12.SolarSystemRepository>()));
  gh.factory<_i16.LoginExecuter>(() => _i16.LoginExecuter(
      get<_i13.AuthorizationRepository>(),
      get<_i11.PlayerRepository>(),
      get<_i5.AuthorizationTokenProvider>(),
      get<_i17.PlayerProvider>(),
      get<_i15.DialogHelper>(),
      get<_i6.NavigationService>()));
  gh.factory<_i18.LoginViewModel>(
      () => _i18.LoginViewModel(get<_i16.LoginExecuter>()));
  gh.factory<_i19.StartViewModel>(() => _i19.StartViewModel(
      get<_i14.FetchSolarSystemExecuter>(), get<_i8.EventService>()));
  gh.singleton<_i5.AuthorizationTokenProvider>(
      _i5.AuthorizationTokenProvider());
  gh.singletonAsync<_i20.DeviceInfo>(() => _i20.DeviceInfo.instance());
  gh.singleton<_i8.EventService>(_i8.EventService());
  gh.singleton<_i17.PlayerProvider>(_i17.PlayerProvider());
  gh.singleton<_i15.DialogHelper>(
      _i15.DialogHelper(get<_i6.NavigationService>()));
  return get;
}

class _$ServicesModule extends _i21.ServicesModule {
  @override
  _i6.NavigationService get navigationService => _i6.NavigationService();
}
