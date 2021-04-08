// GENERATED CODE - DO NOT MODIFY BY HAND

// **************************************************************************
// InjectableConfigGenerator
// **************************************************************************

import 'package:dio/dio.dart' as _i9;
import 'package:get_it/get_it.dart' as _i1;
import 'package:injectable/injectable.dart' as _i2;
import 'package:logger/logger.dart' as _i14;

import '../communications/dtos/add_player_species_request.dart' as _i46;
import '../communications/hubs/building_hub.dart' as _i40;
import '../communications/interceptors/header_interceptor.dart' as _i3;
import '../communications/repositories/authorization_repository.dart' as _i30;
import '../communications/repositories/building_chain_repository.dart' as _i31;
import '../communications/repositories/building_repository.dart' as _i32;
import '../communications/repositories/built_building_repository.dart' as _i35;
import '../communications/repositories/perk_repository.dart' as _i13;
import '../communications/repositories/player_repository.dart' as _i17;
import '../communications/repositories/player_species_repository.dart' as _i18;
import '../communications/repositories/resource_repository.dart' as _i21;
import '../communications/repositories/solar_system_repository.dart' as _i24;
import '../communications/repositories/species_repository.dart' as _i25;
import '../communications/repositories/stellar_object_repository.dart' as _i28;
import '../communications/repositories/stored_resource_repository.dart' as _i29;
import '../communications/server_connection.dart' as _i26;
import '../executers/build_building_executer.dart' as _i51;
import '../executers/fetch_solar_system_executer.dart' as _i38;
import '../executers/login_executer.dart' as _i41;
import '../executers/set_players_species_executer.dart' as _i22;
import '../helpers/dialog_helper.dart' as _i23;
import '../helpers/resource_helper.dart' as _i19;
import '../models/buildings/building.dart' as _i53;
import '../models/players/colonized_stellar_object.dart' as _i37;
import '../providers/authorization_token_provider.dart' as _i11;
import '../providers/building_chain_provider.dart' as _i50;
import '../providers/buildings_provider.dart' as _i34;
import '../providers/constructed_buildings_provider.dart' as _i54;
import '../providers/http_header_provider.dart' as _i10;
import '../providers/player_provider.dart' as _i16;
import '../providers/resource_provider.dart' as _i42;
import '../providers/selected_colonized_stellar_object_provider.dart' as _i12;
import '../providers/stored_resource_provider.dart' as _i20;
import '../services/event_service.dart' as _i7;
import '../services/hub_service.dart' as _i39;
import '../services/navigation_wrapper.dart' as _i8;
import '../views/buildings/buildings_viewmodel.dart' as _i33;
import '../views/buildings/widgets/building_viewmodel.dart' as _i52;
import '../views/home/home_viewmodel.dart' as _i4;
import '../views/home/widgets/constructions_viewmodel.dart' as _i49;
import '../views/login/login_viewmodel.dart' as _i43;
import '../views/menus/colony_viewmodel.dart' as _i36;
import '../views/menus/menu_viewmodel.dart' as _i44;
import '../views/menus/player_colonies_viewmodel.dart' as _i15;
import '../views/menus/resource_viewmodel.dart' as _i47;
import '../views/perk_selection/perk_selection_viewmodel.dart' as _i45;
import '../views/register/register_viewmodel.dart' as _i5;
import '../views/solar_system/solar_system_viewmodel.dart' as _i6;
import '../views/species_selection/species_selection_viewmodel.dart' as _i27;
import '../views/start/start_viewmodel.dart' as _i48;
import 'device_info.dart' as _i55;
import 'services_module.dart' as _i56; // ignore_for_file: unnecessary_lambdas

// ignore_for_file: lines_longer_than_80_chars
/// initializes the registration of provided dependencies inside of [GetIt]
_i1.GetIt $initGetIt(_i1.GetIt get,
    {String environment, _i2.EnvironmentFilter environmentFilter}) {
  final gh = _i2.GetItHelper(get, environment, environmentFilter);
  final servicesModule = _$ServicesModule();
  gh.lazySingleton<_i3.HeaderInterceptor>(() => _i3.HeaderInterceptor());
  gh.factory<_i4.HomeViewModel>(() => _i4.HomeViewModel());
  gh.factory<_i5.RegisterViewModel>(() => _i5.RegisterViewModel());
  gh.factory<_i6.SolarSystemViewModel>(() => _i6.SolarSystemViewModel(
      get<_i7.EventService>(), get<_i8.NavigationWrapper>()));
  gh.factory<_i9.Dio>(() => servicesModule.dio(get<_i3.HeaderInterceptor>()));
  gh.factory<_i10.HttpHeaderProvider>(() => _i10.HttpHeaderProvider(
      get<_i11.AuthorizationTokenProvider>(),
      get<_i12.SelectedColonizedStellarObjectProvider>()));
  gh.factory<_i13.PerkRepository>(
      () => _i13.PerkRepository(get<_i9.Dio>(), get<_i14.Logger>()));
  gh.factory<_i15.PlayerColoniesViewModel>(
      () => _i15.PlayerColoniesViewModel(get<_i16.PlayerProvider>()));
  gh.factory<_i17.PlayerRepository>(
      () => _i17.PlayerRepository(get<_i9.Dio>(), get<_i14.Logger>()));
  gh.factory<_i18.PlayerSpeciesRepository>(
      () => _i18.PlayerSpeciesRepository(get<_i9.Dio>(), get<_i14.Logger>()));
  gh.factory<_i19.ResourceHelper>(
      () => _i19.ResourceHelper(get<_i20.StoredResourceProvider>()));
  gh.factory<_i21.ResourceRepository>(
      () => _i21.ResourceRepository(get<_i9.Dio>(), get<_i14.Logger>()));
  gh.factory<_i22.SetPlayersSpeciesExecuter>(() =>
      _i22.SetPlayersSpeciesExecuter(
          get<_i17.PlayerRepository>(),
          get<_i18.PlayerSpeciesRepository>(),
          get<_i16.PlayerProvider>(),
          get<_i23.DialogHelper>(),
          get<_i8.NavigationWrapper>()));
  gh.factory<_i24.SolarSystemRepository>(
      () => _i24.SolarSystemRepository(get<_i9.Dio>(), get<_i14.Logger>()));
  gh.factory<_i25.SpeciesRepository>(() => _i25.SpeciesRepository(
      get<_i9.Dio>(), get<_i14.Logger>(), get<_i26.ServerConnection>()));
  gh.factory<_i27.SpeciesSelectionViewModel>(() =>
      _i27.SpeciesSelectionViewModel(
          get<_i8.NavigationWrapper>(), get<_i25.SpeciesRepository>()));
  gh.factory<_i28.StellarObjectRepository>(() => _i28.StellarObjectRepository(
      get<_i9.Dio>(), get<_i14.Logger>(), get<_i26.ServerConnection>()));
  gh.factory<_i29.StoredResourceRepository>(
      () => _i29.StoredResourceRepository(get<_i9.Dio>(), get<_i14.Logger>()));
  gh.factory<_i30.AuthorizationRepository>(
      () => _i30.AuthorizationRepository(get<_i9.Dio>(), get<_i14.Logger>()));
  gh.factory<_i31.BuildingChainRepository>(
      () => _i31.BuildingChainRepository(get<_i9.Dio>(), get<_i14.Logger>()));
  gh.factory<_i32.BuildingRepository>(() => _i32.BuildingRepository(
      get<_i9.Dio>(),
      get<_i14.Logger>(),
      get<_i26.ServerConnection>(),
      get<_i10.HttpHeaderProvider>()));
  gh.factory<_i33.BuildingsViewModel>(
      () => _i33.BuildingsViewModel(get<_i34.BuildingsProvider>()));
  gh.factory<_i35.BuiltBuildingRepository>(
      () => _i35.BuiltBuildingRepository(get<_i9.Dio>(), get<_i14.Logger>()));
  gh.factoryParam<_i36.ColonyViewModel, _i37.ColonizedStellarObject, dynamic>(
      (colonizedStellarObject, _) => _i36.ColonyViewModel(
          get<_i12.SelectedColonizedStellarObjectProvider>(),
          get<_i28.StellarObjectRepository>(),
          colonizedStellarObject));
  gh.factory<_i38.FetchSolarSystemExecuter>(() => _i38.FetchSolarSystemExecuter(
      get<_i23.DialogHelper>(), get<_i24.SolarSystemRepository>()));
  gh.factory<_i39.HubService>(() => _i39.HubService(get<_i40.BuildingHub>()));
  gh.factory<_i41.LoginExecuter>(() => _i41.LoginExecuter(
      get<_i30.AuthorizationRepository>(),
      get<_i17.PlayerRepository>(),
      get<_i21.ResourceRepository>(),
      get<_i11.AuthorizationTokenProvider>(),
      get<_i16.PlayerProvider>(),
      get<_i42.ResourceProvider>(),
      get<_i23.DialogHelper>(),
      get<_i8.NavigationWrapper>(),
      get<_i39.HubService>()));
  gh.factory<_i43.LoginViewModel>(() => _i43.LoginViewModel(
      get<_i41.LoginExecuter>(), get<_i8.NavigationWrapper>()));
  gh.factory<_i44.MenuViewModel>(() => _i44.MenuViewModel(
      get<_i8.NavigationWrapper>(),
      get<_i25.SpeciesRepository>(),
      get<_i16.PlayerProvider>()));
  gh.factoryParam<_i45.PerkSelectionViewModel, _i46.AddPlayerSpeciesRequest,
          dynamic>(
      (_playerSpecies, _) => _i45.PerkSelectionViewModel(
          get<_i13.PerkRepository>(),
          get<_i22.SetPlayersSpeciesExecuter>(),
          _playerSpecies));
  gh.factory<_i47.ResourceViewModel>(() => _i47.ResourceViewModel(
      get<_i29.StoredResourceRepository>(),
      get<_i42.ResourceProvider>(),
      get<_i20.StoredResourceProvider>()));
  gh.factory<_i48.StartViewModel>(() => _i48.StartViewModel(
      get<_i38.FetchSolarSystemExecuter>(), get<_i7.EventService>()));
  gh.factory<_i49.ConstructionsViewModel>(() => _i49.ConstructionsViewModel(
      get<_i50.BuildingChainProvider>(),
      get<_i28.StellarObjectRepository>(),
      get<_i7.EventService>()));
  gh.factory<_i51.BuildBuildingExecuter>(() => _i51.BuildBuildingExecuter(
      get<_i23.DialogHelper>(),
      get<_i32.BuildingRepository>(),
      get<_i50.BuildingChainProvider>()));
  gh.factoryParam<_i52.BuildingViewModel, _i53.Building, dynamic>(
      (_building, _) => _i52.BuildingViewModel(
          get<_i32.BuildingRepository>(),
          get<_i50.BuildingChainProvider>(),
          get<_i54.ConstructedBuildingsProvider>(),
          get<_i12.SelectedColonizedStellarObjectProvider>(),
          get<_i51.BuildBuildingExecuter>(),
          get<_i7.EventService>(),
          get<_i19.ResourceHelper>(),
          _building));
  gh.singleton<_i11.AuthorizationTokenProvider>(
      _i11.AuthorizationTokenProvider());
  gh.singletonAsync<_i55.DeviceInfo>(() => _i55.DeviceInfo.instance());
  gh.singleton<_i7.EventService>(_i7.EventService());
  gh.singleton<_i14.Logger>(servicesModule.logger);
  gh.singleton<_i8.NavigationWrapper>(_i8.NavigationWrapper());
  gh.singleton<_i16.PlayerProvider>(_i16.PlayerProvider());
  gh.singleton<_i42.ResourceProvider>(_i42.ResourceProvider());
  gh.singleton<_i12.SelectedColonizedStellarObjectProvider>(
      _i12.SelectedColonizedStellarObjectProvider(get<_i16.PlayerProvider>()));
  gh.singleton<_i26.ServerConnection>(_i26.ServerConnection());
  gh.singleton<_i20.StoredResourceProvider>(_i20.StoredResourceProvider());
  gh.singleton<_i23.DialogHelper>(
      _i23.DialogHelper(get<_i8.NavigationWrapper>()));
  gh.singleton<_i40.BuildingHub>(_i40.BuildingHub(
      get<_i26.ServerConnection>(), get<_i10.HttpHeaderProvider>()));
  gh.singleton<_i34.BuildingsProvider>(
      _i34.BuildingsProvider(get<_i32.BuildingRepository>()));
  gh.singleton<_i54.ConstructedBuildingsProvider>(
      _i54.ConstructedBuildingsProvider(get<_i35.BuiltBuildingRepository>()));
  gh.singleton<_i50.BuildingChainProvider>(_i50.BuildingChainProvider(
      get<_i31.BuildingChainRepository>(), get<_i7.EventService>()));
  return get;
}

class _$ServicesModule extends _i56.ServicesModule {}
