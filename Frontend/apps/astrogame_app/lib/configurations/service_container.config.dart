// GENERATED CODE - DO NOT MODIFY BY HAND

// **************************************************************************
// InjectableConfigGenerator
// **************************************************************************

import 'package:dio/dio.dart' as _i11;
import 'package:get_it/get_it.dart' as _i1;
import 'package:injectable/injectable.dart' as _i2;
import 'package:logger/logger.dart' as _i16;

import '../communications/dtos/add_player_species_request.dart' as _i41;
import '../communications/interceptors/header_interceptor.dart' as _i5;
import '../communications/repositories/authorization_repository.dart' as _i30;
import '../communications/repositories/building_repository.dart' as _i31;
import '../communications/repositories/built_building_repository.dart' as _i32;
import '../communications/repositories/perk_repository.dart' as _i15;
import '../communications/repositories/player_repository.dart' as _i19;
import '../communications/repositories/player_species_repository.dart' as _i20;
import '../communications/repositories/resource_repository.dart' as _i21;
import '../communications/repositories/solar_system_repository.dart' as _i24;
import '../communications/repositories/species_repository.dart' as _i25;
import '../communications/repositories/stellar_object_repository.dart' as _i28;
import '../communications/repositories/stored_resource_repository.dart' as _i29;
import '../communications/server_connection.dart' as _i26;
import '../executers/fetch_solar_system_executer.dart' as _i35;
import '../executers/login_executer.dart' as _i36;
import '../executers/set_players_species_executer.dart' as _i22;
import '../helpers/dialog_helper.dart' as _i23;
import '../models/buildings/building.dart' as _i45;
import '../models/players/colonized_stellar_object.dart' as _i34;
import '../providers/authorization_token_provider.dart' as _i13;
import '../providers/buildings_provider.dart' as _i4;
import '../providers/http_header_provider.dart' as _i12;
import '../providers/player_provider.dart' as _i18;
import '../providers/resource_provider.dart' as _i37;
import '../providers/selected_colonized_stellar_object_provider.dart' as _i14;
import '../services/event_service.dart' as _i9;
import '../services/navigation_wrapper.dart' as _i10;
import '../views/buildings/buildings_viewmodel.dart' as _i3;
import '../views/buildings/widgets/building_viewmodel.dart' as _i44;
import '../views/home/home_viewmodel.dart' as _i6;
import '../views/login/login_viewmodel.dart' as _i38;
import '../views/menus/colony_viewmodel.dart' as _i33;
import '../views/menus/menu_viewmodel.dart' as _i39;
import '../views/menus/player_colonies_viewmodel.dart' as _i17;
import '../views/menus/resource_viewmodel.dart' as _i42;
import '../views/perk_selection/perk_selection_viewmodel.dart' as _i40;
import '../views/register/register_viewmodel.dart' as _i7;
import '../views/solar_system/solar_system_viewmodel.dart' as _i8;
import '../views/species_selection/species_selection_viewmodel.dart' as _i27;
import '../views/start/start_viewmodel.dart' as _i43;
import 'device_info.dart' as _i46;
import 'services_module.dart' as _i47; // ignore_for_file: unnecessary_lambdas

// ignore_for_file: lines_longer_than_80_chars
/// initializes the registration of provided dependencies inside of [GetIt]
_i1.GetIt $initGetIt(_i1.GetIt get,
    {String environment, _i2.EnvironmentFilter environmentFilter}) {
  final gh = _i2.GetItHelper(get, environment, environmentFilter);
  final servicesModule = _$ServicesModule();
  gh.factory<_i3.BuildingsViewModel>(
      () => _i3.BuildingsViewModel(get<_i4.BuildingsProvider>()));
  gh.lazySingleton<_i5.HeaderInterceptor>(() => _i5.HeaderInterceptor());
  gh.factory<_i6.HomeViewModel>(() => _i6.HomeViewModel());
  gh.factory<_i7.RegisterViewModel>(() => _i7.RegisterViewModel());
  gh.factory<_i8.SolarSystemViewModel>(() => _i8.SolarSystemViewModel(
      get<_i9.EventService>(), get<_i10.NavigationWrapper>()));
  gh.factory<_i11.Dio>(() => servicesModule.dio(get<_i5.HeaderInterceptor>()));
  gh.factory<_i12.HttpHeaderProvider>(() => _i12.HttpHeaderProvider(
      get<_i13.AuthorizationTokenProvider>(),
      get<_i14.SelectedColonizedStellarObjectProvider>()));
  gh.factory<_i15.PerkRepository>(
      () => _i15.PerkRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i17.PlayerColoniesViewModel>(
      () => _i17.PlayerColoniesViewModel(get<_i18.PlayerProvider>()));
  gh.factory<_i19.PlayerRepository>(
      () => _i19.PlayerRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i20.PlayerSpeciesRepository>(
      () => _i20.PlayerSpeciesRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i21.ResourceRepository>(
      () => _i21.ResourceRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i22.SetPlayersSpeciesExecuter>(() =>
      _i22.SetPlayersSpeciesExecuter(
          get<_i19.PlayerRepository>(),
          get<_i20.PlayerSpeciesRepository>(),
          get<_i18.PlayerProvider>(),
          get<_i23.DialogHelper>(),
          get<_i10.NavigationWrapper>()));
  gh.factory<_i24.SolarSystemRepository>(
      () => _i24.SolarSystemRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i25.SpeciesRepository>(() => _i25.SpeciesRepository(
      get<_i11.Dio>(), get<_i16.Logger>(), get<_i26.ServerConnection>()));
  gh.factory<_i27.SpeciesSelectionViewModel>(() =>
      _i27.SpeciesSelectionViewModel(
          get<_i10.NavigationWrapper>(), get<_i25.SpeciesRepository>()));
  gh.factory<_i28.StellarObjectRepository>(() => _i28.StellarObjectRepository(
      get<_i11.Dio>(), get<_i16.Logger>(), get<_i26.ServerConnection>()));
  gh.factory<_i29.StoredResourceRepository>(
      () => _i29.StoredResourceRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i30.AuthorizationRepository>(
      () => _i30.AuthorizationRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i31.BuildingRepository>(() => _i31.BuildingRepository(
      get<_i11.Dio>(),
      get<_i16.Logger>(),
      get<_i26.ServerConnection>(),
      get<_i12.HttpHeaderProvider>()));
  gh.factory<_i32.BuiltBuildingRepository>(
      () => _i32.BuiltBuildingRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factoryParam<_i33.ColonyViewModel, _i34.ColonizedStellarObject, dynamic>(
      (colonizedStellarObject, _) => _i33.ColonyViewModel(
          get<_i14.SelectedColonizedStellarObjectProvider>(),
          get<_i28.StellarObjectRepository>(),
          colonizedStellarObject));
  gh.factory<_i35.FetchSolarSystemExecuter>(() => _i35.FetchSolarSystemExecuter(
      get<_i23.DialogHelper>(), get<_i24.SolarSystemRepository>()));
  gh.factory<_i36.LoginExecuter>(() => _i36.LoginExecuter(
      get<_i30.AuthorizationRepository>(),
      get<_i19.PlayerRepository>(),
      get<_i31.BuildingRepository>(),
      get<_i21.ResourceRepository>(),
      get<_i13.AuthorizationTokenProvider>(),
      get<_i18.PlayerProvider>(),
      get<_i4.BuildingsProvider>(),
      get<_i37.ResourceProvider>(),
      get<_i23.DialogHelper>(),
      get<_i10.NavigationWrapper>()));
  gh.factory<_i38.LoginViewModel>(() => _i38.LoginViewModel(
      get<_i36.LoginExecuter>(), get<_i10.NavigationWrapper>()));
  gh.factory<_i39.MenuViewModel>(() => _i39.MenuViewModel(
      get<_i10.NavigationWrapper>(),
      get<_i25.SpeciesRepository>(),
      get<_i18.PlayerProvider>()));
  gh.factoryParam<_i40.PerkSelectionViewModel, _i41.AddPlayerSpeciesRequest,
          dynamic>(
      (_playerSpecies, _) => _i40.PerkSelectionViewModel(
          get<_i15.PerkRepository>(),
          get<_i22.SetPlayersSpeciesExecuter>(),
          _playerSpecies));
  gh.factory<_i42.ResourceViewModel>(() => _i42.ResourceViewModel(
      get<_i29.StoredResourceRepository>(), get<_i37.ResourceProvider>()));
  gh.factory<_i43.StartViewModel>(() => _i43.StartViewModel(
      get<_i35.FetchSolarSystemExecuter>(), get<_i9.EventService>()));
  gh.factoryParam<_i44.BuildingViewModel, _i45.Building, dynamic>(
      (_building, _) => _i44.BuildingViewModel(get<_i31.BuildingRepository>(),
          get<_i32.BuiltBuildingRepository>(), _building));
  gh.singleton<_i13.AuthorizationTokenProvider>(
      _i13.AuthorizationTokenProvider());
  gh.singleton<_i4.BuildingsProvider>(_i4.BuildingsProvider());
  gh.singletonAsync<_i46.DeviceInfo>(() => _i46.DeviceInfo.instance());
  gh.singleton<_i9.EventService>(_i9.EventService());
  gh.singleton<_i16.Logger>(servicesModule.logger);
  gh.singleton<_i10.NavigationWrapper>(_i10.NavigationWrapper());
  gh.singleton<_i18.PlayerProvider>(_i18.PlayerProvider());
  gh.singleton<_i37.ResourceProvider>(_i37.ResourceProvider());
  gh.singleton<_i14.SelectedColonizedStellarObjectProvider>(
      _i14.SelectedColonizedStellarObjectProvider(get<_i18.PlayerProvider>()));
  gh.singleton<_i26.ServerConnection>(_i26.ServerConnection());
  gh.singleton<_i23.DialogHelper>(
      _i23.DialogHelper(get<_i10.NavigationWrapper>()));
  return get;
}

class _$ServicesModule extends _i47.ServicesModule {}
