// GENERATED CODE - DO NOT MODIFY BY HAND

// **************************************************************************
// InjectableConfigGenerator
// **************************************************************************

import 'package:dio/dio.dart' as _i9;
import 'package:get_it/get_it.dart' as _i1;
import 'package:injectable/injectable.dart' as _i2;
import 'package:stacked_services/stacked_services.dart' as _i6;

import '../communications/dtos/add_player_species_request.dart' as _i26;
import '../communications/interceptors/header_interceptor.dart' as _i3;
import '../communications/repositories/authorization_repository.dart' as _i20;
import '../communications/repositories/perk_repository.dart' as _i10;
import '../communications/repositories/player_repository.dart' as _i11;
import '../communications/repositories/player_species_repository.dart' as _i12;
import '../communications/repositories/solar_system_repository.dart' as _i16;
import '../communications/repositories/species_repository.dart' as _i17;
import '../communications/server_connection.dart' as _i18;
import '../executers/fetch_solar_system_executer.dart' as _i21;
import '../executers/login_executer.dart' as _i22;
import '../executers/set_players_species_executer.dart' as _i13;
import '../helpers/dialog_helper.dart' as _i15;
import '../providers/authorization_token_provider.dart' as _i5;
import '../providers/http_header_provider.dart' as _i4;
import '../providers/player_provider.dart' as _i14;
import '../services/event_service.dart' as _i8;
import '../views/login/login_viewmodel.dart' as _i23;
import '../views/menus/menu_viewmodel.dart' as _i24;
import '../views/perk_selection/perk_selection_viewmodel.dart' as _i25;
import '../views/solar_system/solar_system_viewmodel.dart' as _i7;
import '../views/species_selection/species_selection_viewmodel.dart' as _i19;
import '../views/start/start_viewmodel.dart' as _i27;
import 'device_info.dart' as _i28;
import 'services_module.dart' as _i29; // ignore_for_file: unnecessary_lambdas

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
  gh.factory<_i9.Dio>(() => servicesModule.dio(get<_i3.HeaderInterceptor>()));
  gh.factory<_i10.PerkRepository>(() => _i10.PerkRepository(get<_i9.Dio>()));
  gh.factory<_i11.PlayerRepository>(
      () => _i11.PlayerRepository(get<_i9.Dio>()));
  gh.factory<_i12.PlayerSpeciesRepository>(
      () => _i12.PlayerSpeciesRepository(get<_i9.Dio>()));
  gh.factory<_i13.SetPlayersSpeciesExecuter>(() =>
      _i13.SetPlayersSpeciesExecuter(
          get<_i11.PlayerRepository>(),
          get<_i12.PlayerSpeciesRepository>(),
          get<_i14.PlayerProvider>(),
          get<_i15.DialogHelper>(),
          get<_i6.NavigationService>()));
  gh.factory<_i16.SolarSystemRepository>(
      () => _i16.SolarSystemRepository(get<_i9.Dio>()));
  gh.factory<_i17.SpeciesRepository>(() =>
      _i17.SpeciesRepository(get<_i9.Dio>(), get<_i18.ServerConnection>()));
  gh.factory<_i19.SpeciesSelectionViewModel>(() =>
      _i19.SpeciesSelectionViewModel(
          get<_i6.NavigationService>(), get<_i17.SpeciesRepository>()));
  gh.factory<_i20.AuthorizationRepository>(
      () => _i20.AuthorizationRepository(get<_i9.Dio>()));
  gh.factory<_i21.FetchSolarSystemExecuter>(() => _i21.FetchSolarSystemExecuter(
      get<_i15.DialogHelper>(), get<_i16.SolarSystemRepository>()));
  gh.factory<_i22.LoginExecuter>(() => _i22.LoginExecuter(
      get<_i20.AuthorizationRepository>(),
      get<_i11.PlayerRepository>(),
      get<_i5.AuthorizationTokenProvider>(),
      get<_i14.PlayerProvider>(),
      get<_i15.DialogHelper>(),
      get<_i6.NavigationService>()));
  gh.factory<_i23.LoginViewModel>(
      () => _i23.LoginViewModel(get<_i22.LoginExecuter>()));
  gh.factory<_i24.MenuViewModel>(() => _i24.MenuViewModel(
      get<_i6.NavigationService>(),
      get<_i17.SpeciesRepository>(),
      get<_i14.PlayerProvider>()));
  gh.factoryParam<_i25.PerkSelectionViewModel, _i26.AddPlayerSpeciesRequest,
          dynamic>(
      (_playerSpecies, _) => _i25.PerkSelectionViewModel(
          get<_i10.PerkRepository>(),
          get<_i13.SetPlayersSpeciesExecuter>(),
          _playerSpecies));
  gh.factory<_i27.StartViewModel>(() => _i27.StartViewModel(
      get<_i21.FetchSolarSystemExecuter>(), get<_i8.EventService>()));
  gh.singleton<_i5.AuthorizationTokenProvider>(
      _i5.AuthorizationTokenProvider());
  gh.singletonAsync<_i28.DeviceInfo>(() => _i28.DeviceInfo.instance());
  gh.singleton<_i8.EventService>(_i8.EventService());
  gh.singleton<_i14.PlayerProvider>(_i14.PlayerProvider());
  gh.singleton<_i18.ServerConnection>(_i18.ServerConnection());
  gh.singleton<_i15.DialogHelper>(
      _i15.DialogHelper(get<_i6.NavigationService>()));
  return get;
}

class _$ServicesModule extends _i29.ServicesModule {
  @override
  _i6.NavigationService get navigationService => _i6.NavigationService();
}
