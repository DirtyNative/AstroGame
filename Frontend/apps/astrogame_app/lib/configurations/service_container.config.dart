// GENERATED CODE - DO NOT MODIFY BY HAND

// **************************************************************************
// InjectableConfigGenerator
// **************************************************************************

import 'package:dio/dio.dart' as _i10;
import 'package:get_it/get_it.dart' as _i1;
import 'package:injectable/injectable.dart' as _i2;
import 'package:logger/logger.dart' as _i15;

import '../communications/dtos/add_player_species_request.dart' as _i42;
import '../communications/hubs/building_hub.dart' as _i49;
import '../communications/interceptors/header_interceptor.dart' as _i3;
import '../communications/repositories/authorization_repository.dart' as _i29;
import '../communications/repositories/building_chain_repository.dart' as _i30;
import '../communications/repositories/building_repository.dart' as _i31;
import '../communications/repositories/built_building_repository.dart' as _i34;
import '../communications/repositories/perk_repository.dart' as _i14;
import '../communications/repositories/player_repository.dart' as _i18;
import '../communications/repositories/player_species_repository.dart' as _i19;
import '../communications/repositories/resource_repository.dart' as _i20;
import '../communications/repositories/solar_system_repository.dart' as _i23;
import '../communications/repositories/species_repository.dart' as _i24;
import '../communications/repositories/stellar_object_repository.dart' as _i27;
import '../communications/repositories/stored_resource_repository.dart' as _i28;
import '../communications/server_connection.dart' as _i25;
import '../executers/build_building_executer.dart' as _i54;
import '../executers/fetch_solar_system_executer.dart' as _i39;
import '../executers/login_executer.dart' as _i50;
import '../executers/set_players_species_executer.dart' as _i21;
import '../helpers/dialog_helper.dart' as _i22;
import '../helpers/resource_helper.dart' as _i6;
import '../models/buildings/building.dart' as _i56;
import '../models/buildings/building_construction.dart' as _i38;
import '../models/players/colonized_stellar_object.dart' as _i36;
import '../providers/authorization_token_provider.dart' as _i12;
import '../providers/building_chain_provider.dart' as _i47;
import '../providers/buildings_provider.dart' as _i33;
import '../providers/constructed_buildings_provider.dart' as _i57;
import '../providers/http_header_provider.dart' as _i11;
import '../providers/player_provider.dart' as _i17;
import '../providers/resource_provider.dart' as _i44;
import '../providers/selected_colonized_stellar_object_provider.dart' as _i13;
import '../providers/stored_resource_provider.dart' as _i53;
import '../services/event_service.dart' as _i8;
import '../services/hub_service.dart' as _i48;
import '../services/navigation_wrapper.dart' as _i9;
import '../views/buildings/buildings_viewmodel.dart' as _i32;
import '../views/buildings/widgets/building_viewmodel.dart' as _i55;
import '../views/home/home_viewmodel.dart' as _i4;
import '../views/home/widgets/construction_viewmodel.dart' as _i37;
import '../views/home/widgets/constructions_viewmodel.dart' as _i46;
import '../views/login/login_viewmodel.dart' as _i51;
import '../views/menus/colony_viewmodel.dart' as _i35;
import '../views/menus/menu_viewmodel.dart' as _i40;
import '../views/menus/player_colonies_viewmodel.dart' as _i16;
import '../views/menus/resource_viewmodel.dart' as _i52;
import '../views/perk_selection/perk_selection_viewmodel.dart' as _i41;
import '../views/register/register_viewmodel.dart' as _i5;
import '../views/resources/resources_viewmodel.dart' as _i43;
import '../views/solar_system/solar_system_viewmodel.dart' as _i7;
import '../views/species_selection/species_selection_viewmodel.dart' as _i26;
import '../views/start/start_viewmodel.dart' as _i45;
import 'device_info.dart' as _i58;
import 'services_module.dart' as _i59; // ignore_for_file: unnecessary_lambdas

// ignore_for_file: lines_longer_than_80_chars
/// initializes the registration of provided dependencies inside of [GetIt]
_i1.GetIt $initGetIt(_i1.GetIt get,
    {String environment, _i2.EnvironmentFilter environmentFilter}) {
  final gh = _i2.GetItHelper(get, environment, environmentFilter);
  final servicesModule = _$ServicesModule();
  gh.lazySingleton<_i3.HeaderInterceptor>(() => _i3.HeaderInterceptor());
  gh.factory<_i4.HomeViewModel>(() => _i4.HomeViewModel());
  gh.factory<_i5.RegisterViewModel>(() => _i5.RegisterViewModel());
  gh.factory<_i6.ResourceHelper>(() => _i6.ResourceHelper());
  gh.factory<_i7.SolarSystemViewModel>(() => _i7.SolarSystemViewModel(
      get<_i8.EventService>(), get<_i9.NavigationWrapper>()));
  gh.factory<_i10.Dio>(() => servicesModule.dio(get<_i3.HeaderInterceptor>()));
  gh.factory<_i11.HttpHeaderProvider>(() => _i11.HttpHeaderProvider(
      get<_i12.AuthorizationTokenProvider>(),
      get<_i13.SelectedColonizedStellarObjectProvider>()));
  gh.factory<_i14.PerkRepository>(
      () => _i14.PerkRepository(get<_i10.Dio>(), get<_i15.Logger>()));
  gh.factory<_i16.PlayerColoniesViewModel>(
      () => _i16.PlayerColoniesViewModel(get<_i17.PlayerProvider>()));
  gh.factory<_i18.PlayerRepository>(
      () => _i18.PlayerRepository(get<_i10.Dio>(), get<_i15.Logger>()));
  gh.factory<_i19.PlayerSpeciesRepository>(
      () => _i19.PlayerSpeciesRepository(get<_i10.Dio>(), get<_i15.Logger>()));
  gh.factory<_i20.ResourceRepository>(
      () => _i20.ResourceRepository(get<_i10.Dio>(), get<_i15.Logger>()));
  gh.factory<_i21.SetPlayersSpeciesExecuter>(() =>
      _i21.SetPlayersSpeciesExecuter(
          get<_i18.PlayerRepository>(),
          get<_i19.PlayerSpeciesRepository>(),
          get<_i17.PlayerProvider>(),
          get<_i22.DialogHelper>(),
          get<_i9.NavigationWrapper>()));
  gh.factory<_i23.SolarSystemRepository>(
      () => _i23.SolarSystemRepository(get<_i10.Dio>(), get<_i15.Logger>()));
  gh.factory<_i24.SpeciesRepository>(() => _i24.SpeciesRepository(
      get<_i10.Dio>(), get<_i15.Logger>(), get<_i25.ServerConnection>()));
  gh.factory<_i26.SpeciesSelectionViewModel>(() =>
      _i26.SpeciesSelectionViewModel(
          get<_i9.NavigationWrapper>(), get<_i24.SpeciesRepository>()));
  gh.factory<_i27.StellarObjectRepository>(() => _i27.StellarObjectRepository(
      get<_i10.Dio>(), get<_i15.Logger>(), get<_i25.ServerConnection>()));
  gh.factory<_i28.StoredResourceRepository>(
      () => _i28.StoredResourceRepository(get<_i10.Dio>(), get<_i15.Logger>()));
  gh.factory<_i29.AuthorizationRepository>(
      () => _i29.AuthorizationRepository(get<_i10.Dio>(), get<_i15.Logger>()));
  gh.factory<_i30.BuildingChainRepository>(
      () => _i30.BuildingChainRepository(get<_i10.Dio>(), get<_i15.Logger>()));
  gh.factory<_i31.BuildingRepository>(() => _i31.BuildingRepository(
      get<_i10.Dio>(),
      get<_i15.Logger>(),
      get<_i25.ServerConnection>(),
      get<_i11.HttpHeaderProvider>()));
  gh.factory<_i32.BuildingsViewModel>(
      () => _i32.BuildingsViewModel(get<_i33.BuildingsProvider>()));
  gh.factory<_i34.BuiltBuildingRepository>(
      () => _i34.BuiltBuildingRepository(get<_i10.Dio>(), get<_i15.Logger>()));
  gh.factoryParam<_i35.ColonyViewModel, _i36.ColonizedStellarObject, dynamic>(
      (colonizedStellarObject, _) => _i35.ColonyViewModel(
          get<_i13.SelectedColonizedStellarObjectProvider>(),
          get<_i27.StellarObjectRepository>(),
          colonizedStellarObject));
  gh.factoryParam<_i37.ConstructionViewModel, _i38.BuildingConstruction,
          dynamic>(
      (_buildingConstruction, _) => _i37.ConstructionViewModel(
          get<_i27.StellarObjectRepository>(),
          get<_i13.SelectedColonizedStellarObjectProvider>(),
          _buildingConstruction));
  gh.factory<_i39.FetchSolarSystemExecuter>(() => _i39.FetchSolarSystemExecuter(
      get<_i22.DialogHelper>(), get<_i23.SolarSystemRepository>()));
  gh.factory<_i40.MenuViewModel>(() => _i40.MenuViewModel(
      get<_i9.NavigationWrapper>(),
      get<_i24.SpeciesRepository>(),
      get<_i17.PlayerProvider>()));
  gh.factoryParam<_i41.PerkSelectionViewModel, _i42.AddPlayerSpeciesRequest,
          dynamic>(
      (_playerSpecies, _) => _i41.PerkSelectionViewModel(
          get<_i14.PerkRepository>(),
          get<_i21.SetPlayersSpeciesExecuter>(),
          _playerSpecies));
  gh.factory<_i43.ResourcesViewModel>(
      () => _i43.ResourcesViewModel(get<_i44.ResourceProvider>()));
  gh.factory<_i45.StartViewModel>(() => _i45.StartViewModel(
      get<_i39.FetchSolarSystemExecuter>(), get<_i8.EventService>()));
  gh.factory<_i46.ConstructionsViewModel>(() => _i46.ConstructionsViewModel(
      get<_i47.BuildingChainProvider>(), get<_i8.EventService>()));
  gh.factory<_i48.HubService>(() => _i48.HubService(get<_i49.BuildingHub>()));
  gh.factory<_i50.LoginExecuter>(() => _i50.LoginExecuter(
      get<_i29.AuthorizationRepository>(),
      get<_i18.PlayerRepository>(),
      get<_i12.AuthorizationTokenProvider>(),
      get<_i17.PlayerProvider>(),
      get<_i22.DialogHelper>(),
      get<_i9.NavigationWrapper>(),
      get<_i48.HubService>()));
  gh.factory<_i51.LoginViewModel>(() => _i51.LoginViewModel(
      get<_i50.LoginExecuter>(), get<_i9.NavigationWrapper>()));
  gh.factory<_i52.ResourceViewModel>(() => _i52.ResourceViewModel(
      get<_i8.EventService>(),
      get<_i44.ResourceProvider>(),
      get<_i53.StoredResourceProvider>()));
  gh.factory<_i54.BuildBuildingExecuter>(() => _i54.BuildBuildingExecuter(
      get<_i8.EventService>(),
      get<_i22.DialogHelper>(),
      get<_i31.BuildingRepository>(),
      get<_i47.BuildingChainProvider>()));
  gh.factoryParam<_i55.BuildingViewModel, _i56.Building, dynamic>(
      (_building, _) => _i55.BuildingViewModel(
          get<_i31.BuildingRepository>(),
          get<_i47.BuildingChainProvider>(),
          get<_i57.ConstructedBuildingsProvider>(),
          get<_i13.SelectedColonizedStellarObjectProvider>(),
          get<_i53.StoredResourceProvider>(),
          get<_i54.BuildBuildingExecuter>(),
          get<_i8.EventService>(),
          get<_i6.ResourceHelper>(),
          _building));
  gh.singleton<_i12.AuthorizationTokenProvider>(
      _i12.AuthorizationTokenProvider());
  gh.singletonAsync<_i58.DeviceInfo>(() => _i58.DeviceInfo.instance());
  gh.singleton<_i8.EventService>(_i8.EventService());
  gh.singleton<_i15.Logger>(servicesModule.logger);
  gh.singleton<_i9.NavigationWrapper>(_i9.NavigationWrapper());
  gh.singleton<_i17.PlayerProvider>(_i17.PlayerProvider());
  gh.singleton<_i13.SelectedColonizedStellarObjectProvider>(
      _i13.SelectedColonizedStellarObjectProvider(get<_i17.PlayerProvider>()));
  gh.singleton<_i25.ServerConnection>(_i25.ServerConnection());
  gh.singleton<_i22.DialogHelper>(
      _i22.DialogHelper(get<_i9.NavigationWrapper>()));
  gh.singleton<_i33.BuildingsProvider>(
      _i33.BuildingsProvider(get<_i31.BuildingRepository>()));
  gh.singleton<_i57.ConstructedBuildingsProvider>(
      _i57.ConstructedBuildingsProvider(get<_i34.BuiltBuildingRepository>()));
  gh.singleton<_i44.ResourceProvider>(
      _i44.ResourceProvider(get<_i20.ResourceRepository>()));
  gh.singleton<_i53.StoredResourceProvider>(
      _i53.StoredResourceProvider(get<_i28.StoredResourceRepository>()));
  gh.singleton<_i47.BuildingChainProvider>(
      _i47.BuildingChainProvider(get<_i30.BuildingChainRepository>()));
  gh.singleton<_i49.BuildingHub>(_i49.BuildingHub(
      get<_i8.EventService>(),
      get<_i25.ServerConnection>(),
      get<_i11.HttpHeaderProvider>(),
      get<_i47.BuildingChainProvider>(),
      get<_i57.ConstructedBuildingsProvider>()));
  return get;
}

class _$ServicesModule extends _i59.ServicesModule {}
