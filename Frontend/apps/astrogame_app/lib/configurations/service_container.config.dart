// GENERATED CODE - DO NOT MODIFY BY HAND

// **************************************************************************
// InjectableConfigGenerator
// **************************************************************************

import 'package:dio/dio.dart' as _i10;
import 'package:get_it/get_it.dart' as _i1;
import 'package:injectable/injectable.dart' as _i2;
import 'package:stacked_services/stacked_services.dart' as _i6;

import '../communications/dtos/add_player_species_request.dart' as _i32;
import '../communications/interceptors/header_interceptor.dart' as _i3;
import '../communications/repositories/authorization_repository.dart' as _i23;
import '../communications/repositories/perk_repository.dart' as _i11;
import '../communications/repositories/player_repository.dart' as _i14;
import '../communications/repositories/player_species_repository.dart' as _i15;
import '../communications/repositories/solar_system_repository.dart' as _i18;
import '../communications/repositories/species_repository.dart' as _i19;
import '../communications/repositories/stellar_object_repository.dart' as _i22;
import '../communications/server_connection.dart' as _i20;
import '../executers/fetch_solar_system_executer.dart' as _i27;
import '../executers/login_executer.dart' as _i28;
import '../executers/set_players_species_executer.dart' as _i16;
import '../helpers/dialog_helper.dart' as _i17;
import '../models/players/colonized_stellar_object.dart' as _i25;
import '../providers/authorization_token_provider.dart' as _i5;
import '../providers/http_header_provider.dart' as _i4;
import '../providers/player_provider.dart' as _i13;
import '../providers/selected_stellar_object_provider.dart' as _i26;
import '../services/event_service.dart' as _i9;
import '../views/login/login_viewmodel.dart' as _i29;
import '../views/menus/colony_viewmodel.dart' as _i24;
import '../views/menus/menu_viewmodel.dart' as _i30;
import '../views/menus/player_colonies_viewmodel.dart' as _i12;
import '../views/perk_selection/perk_selection_viewmodel.dart' as _i31;
import '../views/register/register_viewmodel.dart' as _i7;
import '../views/solar_system/solar_system_viewmodel.dart' as _i8;
import '../views/species_selection/species_selection_viewmodel.dart' as _i21;
import '../views/start/start_viewmodel.dart' as _i33;
import 'device_info.dart' as _i34;
import 'services_module.dart' as _i35; // ignore_for_file: unnecessary_lambdas

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
  gh.factory<_i7.RegisterViewModel>(() => _i7.RegisterViewModel());
  gh.factory<_i8.SolarSystemViewModel>(() => _i8.SolarSystemViewModel(
      get<_i9.EventService>(), get<_i6.NavigationService>()));
  gh.factory<_i10.Dio>(() => servicesModule.dio(get<_i3.HeaderInterceptor>()));
  gh.factory<_i11.PerkRepository>(() => _i11.PerkRepository(get<_i10.Dio>()));
  gh.factory<_i12.PlayerColoniesViewModel>(
      () => _i12.PlayerColoniesViewModel(get<_i13.PlayerProvider>()));
  gh.factory<_i14.PlayerRepository>(
      () => _i14.PlayerRepository(get<_i10.Dio>()));
  gh.factory<_i15.PlayerSpeciesRepository>(
      () => _i15.PlayerSpeciesRepository(get<_i10.Dio>()));
  gh.factory<_i16.SetPlayersSpeciesExecuter>(() =>
      _i16.SetPlayersSpeciesExecuter(
          get<_i14.PlayerRepository>(),
          get<_i15.PlayerSpeciesRepository>(),
          get<_i13.PlayerProvider>(),
          get<_i17.DialogHelper>(),
          get<_i6.NavigationService>()));
  gh.factory<_i18.SolarSystemRepository>(
      () => _i18.SolarSystemRepository(get<_i10.Dio>()));
  gh.factory<_i19.SpeciesRepository>(() =>
      _i19.SpeciesRepository(get<_i10.Dio>(), get<_i20.ServerConnection>()));
  gh.factory<_i21.SpeciesSelectionViewModel>(() =>
      _i21.SpeciesSelectionViewModel(
          get<_i6.NavigationService>(), get<_i19.SpeciesRepository>()));
  gh.factory<_i22.StellarObjectRepository>(() => _i22.StellarObjectRepository(
      get<_i10.Dio>(), get<_i20.ServerConnection>()));
  gh.factory<_i23.AuthorizationRepository>(
      () => _i23.AuthorizationRepository(get<_i10.Dio>()));
  gh.factoryParam<_i24.ColonyViewModel, _i25.ColonizedStellarObject, dynamic>(
      (colonizedStellarObject, _) => _i24.ColonyViewModel(
          get<_i26.SelectedStellarObjectProvider>(),
          get<_i22.StellarObjectRepository>(),
          colonizedStellarObject));
  gh.factory<_i27.FetchSolarSystemExecuter>(() => _i27.FetchSolarSystemExecuter(
      get<_i17.DialogHelper>(), get<_i18.SolarSystemRepository>()));
  gh.factory<_i28.LoginExecuter>(() => _i28.LoginExecuter(
      get<_i23.AuthorizationRepository>(),
      get<_i14.PlayerRepository>(),
      get<_i5.AuthorizationTokenProvider>(),
      get<_i13.PlayerProvider>(),
      get<_i17.DialogHelper>(),
      get<_i6.NavigationService>()));
  gh.factory<_i29.LoginViewModel>(() => _i29.LoginViewModel(
      get<_i28.LoginExecuter>(), get<_i6.NavigationService>()));
  gh.factory<_i30.MenuViewModel>(() => _i30.MenuViewModel(
      get<_i6.NavigationService>(),
      get<_i19.SpeciesRepository>(),
      get<_i13.PlayerProvider>()));
  gh.factoryParam<_i31.PerkSelectionViewModel, _i32.AddPlayerSpeciesRequest,
          dynamic>(
      (_playerSpecies, _) => _i31.PerkSelectionViewModel(
          get<_i11.PerkRepository>(),
          get<_i16.SetPlayersSpeciesExecuter>(),
          _playerSpecies));
  gh.factory<_i33.StartViewModel>(() => _i33.StartViewModel(
      get<_i27.FetchSolarSystemExecuter>(), get<_i9.EventService>()));
  gh.singleton<_i5.AuthorizationTokenProvider>(
      _i5.AuthorizationTokenProvider());
  gh.singletonAsync<_i34.DeviceInfo>(() => _i34.DeviceInfo.instance());
  gh.singleton<_i9.EventService>(_i9.EventService());
  gh.singleton<_i13.PlayerProvider>(_i13.PlayerProvider());
  gh.singleton<_i26.SelectedStellarObjectProvider>(
      _i26.SelectedStellarObjectProvider(get<_i13.PlayerProvider>()));
  gh.singleton<_i20.ServerConnection>(_i20.ServerConnection());
  gh.singleton<_i17.DialogHelper>(
      _i17.DialogHelper(get<_i6.NavigationService>()));
  return get;
}

class _$ServicesModule extends _i35.ServicesModule {
  @override
  _i6.NavigationService get navigationService => _i6.NavigationService();
}
