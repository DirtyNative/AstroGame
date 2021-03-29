// GENERATED CODE - DO NOT MODIFY BY HAND

// **************************************************************************
// InjectableConfigGenerator
// **************************************************************************

import 'package:dio/dio.dart' as _i10;
import 'package:get_it/get_it.dart' as _i1;
import 'package:injectable/injectable.dart' as _i2;
import 'package:logger/logger.dart' as _i12;

import '../communications/dtos/add_player_species_request.dart' as _i36;
import '../communications/interceptors/header_interceptor.dart' as _i3;
import '../communications/repositories/authorization_repository.dart' as _i24;
import '../communications/repositories/building_repository.dart' as _i25;
import '../communications/repositories/perk_repository.dart' as _i11;
import '../communications/repositories/player_repository.dart' as _i15;
import '../communications/repositories/player_species_repository.dart' as _i16;
import '../communications/repositories/solar_system_repository.dart' as _i19;
import '../communications/repositories/species_repository.dart' as _i20;
import '../communications/repositories/stellar_object_repository.dart' as _i23;
import '../communications/server_connection.dart' as _i21;
import '../executers/fetch_solar_system_executer.dart' as _i31;
import '../executers/login_executer.dart' as _i32;
import '../executers/set_players_species_executer.dart' as _i17;
import '../helpers/dialog_helper.dart' as _i18;
import '../models/players/colonized_stellar_object.dart' as _i29;
import '../providers/authorization_token_provider.dart' as _i5;
import '../providers/buildings_provider.dart' as _i27;
import '../providers/http_header_provider.dart' as _i4;
import '../providers/player_provider.dart' as _i14;
import '../providers/selected_stellar_object_provider.dart' as _i30;
import '../services/event_service.dart' as _i8;
import '../services/navigation_wrapper.dart' as _i9;
import '../views/buildings/buildings_viewmodel.dart' as _i26;
import '../views/login/login_viewmodel.dart' as _i33;
import '../views/menus/colony_viewmodel.dart' as _i28;
import '../views/menus/menu_viewmodel.dart' as _i34;
import '../views/menus/player_colonies_viewmodel.dart' as _i13;
import '../views/perk_selection/perk_selection_viewmodel.dart' as _i35;
import '../views/register/register_viewmodel.dart' as _i6;
import '../views/solar_system/solar_system_viewmodel.dart' as _i7;
import '../views/species_selection/species_selection_viewmodel.dart' as _i22;
import '../views/start/start_viewmodel.dart' as _i37;
import 'device_info.dart' as _i38;
import 'services_module.dart' as _i39; // ignore_for_file: unnecessary_lambdas

// ignore_for_file: lines_longer_than_80_chars
/// initializes the registration of provided dependencies inside of [GetIt]
_i1.GetIt $initGetIt(_i1.GetIt get,
    {String environment, _i2.EnvironmentFilter environmentFilter}) {
  final gh = _i2.GetItHelper(get, environment, environmentFilter);
  final servicesModule = _$ServicesModule();
  gh.lazySingleton<_i3.HeaderInterceptor>(() => _i3.HeaderInterceptor());
  gh.factory<_i4.HttpHeaderProvider>(
      () => _i4.HttpHeaderProvider(get<_i5.AuthorizationTokenProvider>()));
  gh.factory<_i6.RegisterViewModel>(() => _i6.RegisterViewModel());
  gh.factory<_i7.SolarSystemViewModel>(() => _i7.SolarSystemViewModel(
      get<_i8.EventService>(), get<_i9.NavigationWrapper>()));
  gh.factory<_i10.Dio>(() => servicesModule.dio(get<_i3.HeaderInterceptor>()));
  gh.factory<_i11.PerkRepository>(
      () => _i11.PerkRepository(get<_i10.Dio>(), get<_i12.Logger>()));
  gh.factory<_i13.PlayerColoniesViewModel>(
      () => _i13.PlayerColoniesViewModel(get<_i14.PlayerProvider>()));
  gh.factory<_i15.PlayerRepository>(
      () => _i15.PlayerRepository(get<_i10.Dio>(), get<_i12.Logger>()));
  gh.factory<_i16.PlayerSpeciesRepository>(
      () => _i16.PlayerSpeciesRepository(get<_i10.Dio>(), get<_i12.Logger>()));
  gh.factory<_i17.SetPlayersSpeciesExecuter>(() =>
      _i17.SetPlayersSpeciesExecuter(
          get<_i15.PlayerRepository>(),
          get<_i16.PlayerSpeciesRepository>(),
          get<_i14.PlayerProvider>(),
          get<_i18.DialogHelper>(),
          get<_i9.NavigationWrapper>()));
  gh.factory<_i19.SolarSystemRepository>(
      () => _i19.SolarSystemRepository(get<_i10.Dio>(), get<_i12.Logger>()));
  gh.factory<_i20.SpeciesRepository>(() => _i20.SpeciesRepository(
      get<_i10.Dio>(), get<_i12.Logger>(), get<_i21.ServerConnection>()));
  gh.factory<_i22.SpeciesSelectionViewModel>(() =>
      _i22.SpeciesSelectionViewModel(
          get<_i9.NavigationWrapper>(), get<_i20.SpeciesRepository>()));
  gh.factory<_i23.StellarObjectRepository>(() => _i23.StellarObjectRepository(
      get<_i10.Dio>(), get<_i12.Logger>(), get<_i21.ServerConnection>()));
  gh.factory<_i24.AuthorizationRepository>(
      () => _i24.AuthorizationRepository(get<_i10.Dio>(), get<_i12.Logger>()));
  gh.factory<_i25.BuildingRepository>(() => _i25.BuildingRepository(
      get<_i10.Dio>(),
      get<_i12.Logger>(),
      get<_i21.ServerConnection>(),
      get<_i4.HttpHeaderProvider>()));
  gh.factory<_i26.BuildingsViewModel>(() => _i26.BuildingsViewModel(
      get<_i27.BuildingsProvider>(), get<_i25.BuildingRepository>()));
  gh.factoryParam<_i28.ColonyViewModel, _i29.ColonizedStellarObject, dynamic>(
      (colonizedStellarObject, _) => _i28.ColonyViewModel(
          get<_i30.SelectedStellarObjectProvider>(),
          get<_i23.StellarObjectRepository>(),
          colonizedStellarObject));
  gh.factory<_i31.FetchSolarSystemExecuter>(() => _i31.FetchSolarSystemExecuter(
      get<_i18.DialogHelper>(), get<_i19.SolarSystemRepository>()));
  gh.factory<_i32.LoginExecuter>(() => _i32.LoginExecuter(
      get<_i24.AuthorizationRepository>(),
      get<_i15.PlayerRepository>(),
      get<_i25.BuildingRepository>(),
      get<_i5.AuthorizationTokenProvider>(),
      get<_i14.PlayerProvider>(),
      get<_i27.BuildingsProvider>(),
      get<_i18.DialogHelper>(),
      get<_i9.NavigationWrapper>()));
  gh.factory<_i33.LoginViewModel>(() => _i33.LoginViewModel(
      get<_i32.LoginExecuter>(), get<_i9.NavigationWrapper>()));
  gh.factory<_i34.MenuViewModel>(() => _i34.MenuViewModel(
      get<_i9.NavigationWrapper>(),
      get<_i20.SpeciesRepository>(),
      get<_i14.PlayerProvider>()));
  gh.factoryParam<_i35.PerkSelectionViewModel, _i36.AddPlayerSpeciesRequest,
          dynamic>(
      (_playerSpecies, _) => _i35.PerkSelectionViewModel(
          get<_i11.PerkRepository>(),
          get<_i17.SetPlayersSpeciesExecuter>(),
          _playerSpecies));
  gh.factory<_i37.StartViewModel>(() => _i37.StartViewModel(
      get<_i31.FetchSolarSystemExecuter>(), get<_i8.EventService>()));
  gh.singleton<_i5.AuthorizationTokenProvider>(
      _i5.AuthorizationTokenProvider());
  gh.singleton<_i27.BuildingsProvider>(_i27.BuildingsProvider());
  gh.singletonAsync<_i38.DeviceInfo>(() => _i38.DeviceInfo.instance());
  gh.singleton<_i8.EventService>(_i8.EventService());
  gh.singleton<_i12.Logger>(servicesModule.logger);
  gh.singleton<_i9.NavigationWrapper>(_i9.NavigationWrapper());
  gh.singleton<_i14.PlayerProvider>(_i14.PlayerProvider());
  gh.singleton<_i30.SelectedStellarObjectProvider>(
      _i30.SelectedStellarObjectProvider(get<_i14.PlayerProvider>()));
  gh.singleton<_i21.ServerConnection>(_i21.ServerConnection());
  gh.singleton<_i18.DialogHelper>(
      _i18.DialogHelper(get<_i9.NavigationWrapper>()));
  return get;
}

class _$ServicesModule extends _i39.ServicesModule {}
