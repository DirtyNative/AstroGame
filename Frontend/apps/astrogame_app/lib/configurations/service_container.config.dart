// GENERATED CODE - DO NOT MODIFY BY HAND

// **************************************************************************
// InjectableConfigGenerator
// **************************************************************************

import 'package:dio/dio.dart' as _i11;
import 'package:get_it/get_it.dart' as _i1;
import 'package:injectable/injectable.dart' as _i2;
import 'package:logger/logger.dart' as _i16;

import '../communications/dtos/add_player_species_request.dart' as _i44;
import '../communications/hubs/building_hub.dart' as _i56;
import '../communications/interceptors/header_interceptor.dart' as _i3;
import '../communications/repositories/authorization_repository.dart' as _i31;
import '../communications/repositories/building_chain_repository.dart' as _i32;
import '../communications/repositories/building_repository.dart' as _i33;
import '../communications/repositories/built_building_repository.dart' as _i36;
import '../communications/repositories/perk_repository.dart' as _i15;
import '../communications/repositories/player_repository.dart' as _i19;
import '../communications/repositories/player_species_repository.dart' as _i20;
import '../communications/repositories/resource_repository.dart' as _i21;
import '../communications/repositories/resource_snapshot_repository.dart'
    as _i22;
import '../communications/repositories/solar_system_repository.dart' as _i25;
import '../communications/repositories/species_repository.dart' as _i26;
import '../communications/repositories/stellar_object_repository.dart' as _i29;
import '../communications/repositories/stored_resource_repository.dart' as _i30;
import '../communications/server_connection.dart' as _i27;
import '../executers/build_building_executer.dart' as _i61;
import '../executers/fetch_solar_system_executer.dart' as _i41;
import '../executers/login_executer.dart' as _i57;
import '../executers/set_players_species_executer.dart' as _i23;
import '../helpers/dialog_helper.dart' as _i24;
import '../helpers/resource_helper.dart' as _i7;
import '../models/buildings/building.dart' as _i63;
import '../models/buildings/building_construction.dart' as _i40;
import '../models/buildings/building_cost.dart' as _i47;
import '../models/buildings/built_building.dart' as _i64;
import '../models/players/colonized_stellar_object.dart' as _i38;
import '../models/resources/resource.dart' as _i46;
import '../providers/authorization_token_provider.dart' as _i13;
import '../providers/building_chain_provider.dart' as _i54;
import '../providers/building_image_provider.dart' as _i65;
import '../providers/buildings_provider.dart' as _i35;
import '../providers/constructed_buildings_provider.dart' as _i67;
import '../providers/http_header_provider.dart' as _i12;
import '../providers/player_provider.dart' as _i18;
import '../providers/resource_provider.dart' as _i51;
import '../providers/resource_snapshot_provider.dart' as _i48;
import '../providers/selected_colonized_stellar_object_provider.dart' as _i14;
import '../providers/stored_resource_provider.dart' as _i60;
import '../services/event_service.dart' as _i9;
import '../services/hub_service.dart' as _i55;
import '../services/navigation_wrapper.dart' as _i10;
import '../views/building_detail/building_detail_viewmodel.dart' as _i62;
import '../views/building_detail/widgets/resource_viewmodel.dart' as _i45;
import '../views/buildings/buildings_viewmodel.dart' as _i34;
import '../views/buildings/widgets/building_viewmodel.dart' as _i66;
import '../views/home/home_viewmodel.dart' as _i4;
import '../views/home/widgets/construction_viewmodel.dart' as _i39;
import '../views/home/widgets/constructions_viewmodel.dart' as _i53;
import '../views/login/login_viewmodel.dart' as _i58;
import '../views/market/market_viewmodel.dart' as _i5;
import '../views/menus/colony_viewmodel.dart' as _i37;
import '../views/menus/menu_viewmodel.dart' as _i42;
import '../views/menus/player_colonies_viewmodel.dart' as _i17;
import '../views/menus/resource_viewmodel.dart' as _i59;
import '../views/perk_selection/perk_selection_viewmodel.dart' as _i43;
import '../views/register/register_viewmodel.dart' as _i6;
import '../views/resources/resources_viewmodel.dart' as _i50;
import '../views/resources/widgets/resource_viewmodel.dart' as _i49;
import '../views/solar_system/solar_system_viewmodel.dart' as _i8;
import '../views/species_selection/species_selection_viewmodel.dart' as _i28;
import '../views/start/start_viewmodel.dart' as _i52;
import 'device_info.dart' as _i68;
import 'services_module.dart' as _i69; // ignore_for_file: unnecessary_lambdas

// ignore_for_file: lines_longer_than_80_chars
/// initializes the registration of provided dependencies inside of [GetIt]
_i1.GetIt $initGetIt(_i1.GetIt get,
    {String environment, _i2.EnvironmentFilter environmentFilter}) {
  final gh = _i2.GetItHelper(get, environment, environmentFilter);
  final servicesModule = _$ServicesModule();
  gh.lazySingleton<_i3.HeaderInterceptor>(() => _i3.HeaderInterceptor());
  gh.factory<_i4.HomeViewModel>(() => _i4.HomeViewModel());
  gh.factory<_i5.MarketViewModel>(() => _i5.MarketViewModel());
  gh.factory<_i6.RegisterViewModel>(() => _i6.RegisterViewModel());
  gh.factory<_i7.ResourceHelper>(() => _i7.ResourceHelper());
  gh.factory<_i8.SolarSystemViewModel>(() => _i8.SolarSystemViewModel(
      get<_i9.EventService>(), get<_i10.NavigationWrapper>()));
  gh.factory<_i11.Dio>(() => servicesModule.dio(get<_i3.HeaderInterceptor>()));
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
  gh.factory<_i22.ResourceSnapshotRepository>(() =>
      _i22.ResourceSnapshotRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i23.SetPlayersSpeciesExecuter>(() =>
      _i23.SetPlayersSpeciesExecuter(
          get<_i19.PlayerRepository>(),
          get<_i20.PlayerSpeciesRepository>(),
          get<_i18.PlayerProvider>(),
          get<_i24.DialogHelper>(),
          get<_i10.NavigationWrapper>()));
  gh.factory<_i25.SolarSystemRepository>(
      () => _i25.SolarSystemRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i26.SpeciesRepository>(() => _i26.SpeciesRepository(
      get<_i11.Dio>(), get<_i16.Logger>(), get<_i27.ServerConnection>()));
  gh.factory<_i28.SpeciesSelectionViewModel>(() =>
      _i28.SpeciesSelectionViewModel(
          get<_i10.NavigationWrapper>(), get<_i26.SpeciesRepository>()));
  gh.factory<_i29.StellarObjectRepository>(() => _i29.StellarObjectRepository(
      get<_i11.Dio>(), get<_i16.Logger>(), get<_i27.ServerConnection>()));
  gh.factory<_i30.StoredResourceRepository>(
      () => _i30.StoredResourceRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i31.AuthorizationRepository>(
      () => _i31.AuthorizationRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i32.BuildingChainRepository>(
      () => _i32.BuildingChainRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i33.BuildingRepository>(() => _i33.BuildingRepository(
      get<_i11.Dio>(),
      get<_i16.Logger>(),
      get<_i27.ServerConnection>(),
      get<_i12.HttpHeaderProvider>()));
  gh.factory<_i34.BuildingsViewModel>(
      () => _i34.BuildingsViewModel(get<_i35.BuildingsProvider>()));
  gh.factory<_i36.BuiltBuildingRepository>(
      () => _i36.BuiltBuildingRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factoryParam<_i37.ColonyViewModel, _i38.ColonizedStellarObject, dynamic>(
      (colonizedStellarObject, _) => _i37.ColonyViewModel(
          get<_i14.SelectedColonizedStellarObjectProvider>(),
          get<_i29.StellarObjectRepository>(),
          colonizedStellarObject));
  gh.factoryParam<_i39.ConstructionViewModel, _i40.BuildingConstruction,
          dynamic>(
      (_buildingConstruction, _) => _i39.ConstructionViewModel(
          get<_i29.StellarObjectRepository>(),
          get<_i14.SelectedColonizedStellarObjectProvider>(),
          _buildingConstruction));
  gh.factory<_i41.FetchSolarSystemExecuter>(() => _i41.FetchSolarSystemExecuter(
      get<_i24.DialogHelper>(), get<_i25.SolarSystemRepository>()));
  gh.factory<_i42.MenuViewModel>(() => _i42.MenuViewModel(
      get<_i10.NavigationWrapper>(),
      get<_i26.SpeciesRepository>(),
      get<_i18.PlayerProvider>()));
  gh.factoryParam<_i43.PerkSelectionViewModel, _i44.AddPlayerSpeciesRequest,
          dynamic>(
      (_playerSpecies, _) => _i43.PerkSelectionViewModel(
          get<_i15.PerkRepository>(),
          get<_i23.SetPlayersSpeciesExecuter>(),
          _playerSpecies));
  gh.factoryParam<_i45.ResourceViewModel, _i46.Resource, _i47.BuildingCost>(
      (_resource, _buildingCost) => _i45.ResourceViewModel(
          get<_i9.EventService>(),
          get<_i48.ResourceSnapshotProvider>(),
          get<_i14.SelectedColonizedStellarObjectProvider>(),
          _resource,
          _buildingCost));
  gh.factoryParam<_i49.ResourceViewModel, _i46.Resource, dynamic>(
      (_resource, _) => _i49.ResourceViewModel(
          get<_i9.EventService>(),
          get<_i48.ResourceSnapshotProvider>(),
          get<_i14.SelectedColonizedStellarObjectProvider>(),
          _resource));
  gh.factory<_i50.ResourcesViewModel>(
      () => _i50.ResourcesViewModel(get<_i51.ResourceProvider>()));
  gh.factory<_i52.StartViewModel>(() => _i52.StartViewModel(
      get<_i41.FetchSolarSystemExecuter>(), get<_i9.EventService>()));
  gh.factory<_i53.ConstructionsViewModel>(() => _i53.ConstructionsViewModel(
      get<_i54.BuildingChainProvider>(), get<_i9.EventService>()));
  gh.factory<_i55.HubService>(() => _i55.HubService(get<_i56.BuildingHub>()));
  gh.factory<_i57.LoginExecuter>(() => _i57.LoginExecuter(
      get<_i31.AuthorizationRepository>(),
      get<_i19.PlayerRepository>(),
      get<_i13.AuthorizationTokenProvider>(),
      get<_i18.PlayerProvider>(),
      get<_i24.DialogHelper>(),
      get<_i10.NavigationWrapper>(),
      get<_i55.HubService>()));
  gh.factory<_i58.LoginViewModel>(() => _i58.LoginViewModel(
      get<_i57.LoginExecuter>(), get<_i10.NavigationWrapper>()));
  gh.factory<_i59.ResourceViewModel>(() => _i59.ResourceViewModel(
      get<_i9.EventService>(),
      get<_i51.ResourceProvider>(),
      get<_i60.StoredResourceProvider>()));
  gh.factory<_i61.BuildBuildingExecuter>(() => _i61.BuildBuildingExecuter(
      get<_i9.EventService>(),
      get<_i24.DialogHelper>(),
      get<_i33.BuildingRepository>(),
      get<_i54.BuildingChainProvider>(),
      get<_i60.StoredResourceProvider>()));
  gh.factoryParam<_i62.BuildingDetailViewModel, _i63.Building,
          _i64.BuiltBuilding>(
      (building, builtBuilding) => _i62.BuildingDetailViewModel(
          get<_i33.BuildingRepository>(),
          get<_i51.ResourceProvider>(),
          get<_i65.BuildingImageProvider>(),
          building,
          builtBuilding));
  gh.factoryParam<_i66.BuildingViewModel, _i63.Building, dynamic>(
      (_building, _) => _i66.BuildingViewModel(
          get<_i10.NavigationWrapper>(),
          get<_i54.BuildingChainProvider>(),
          get<_i67.ConstructedBuildingsProvider>(),
          get<_i14.SelectedColonizedStellarObjectProvider>(),
          get<_i65.BuildingImageProvider>(),
          get<_i60.StoredResourceProvider>(),
          get<_i61.BuildBuildingExecuter>(),
          get<_i9.EventService>(),
          get<_i7.ResourceHelper>(),
          _building));
  gh.singleton<_i13.AuthorizationTokenProvider>(
      _i13.AuthorizationTokenProvider());
  gh.singletonAsync<_i68.DeviceInfo>(() => _i68.DeviceInfo.instance());
  gh.singleton<_i9.EventService>(_i9.EventService());
  gh.singleton<_i16.Logger>(servicesModule.logger);
  gh.singleton<_i10.NavigationWrapper>(_i10.NavigationWrapper());
  gh.singleton<_i18.PlayerProvider>(_i18.PlayerProvider());
  gh.singleton<_i14.SelectedColonizedStellarObjectProvider>(
      _i14.SelectedColonizedStellarObjectProvider(get<_i18.PlayerProvider>()));
  gh.singleton<_i27.ServerConnection>(_i27.ServerConnection());
  gh.singleton<_i24.DialogHelper>(
      _i24.DialogHelper(get<_i10.NavigationWrapper>()));
  gh.singleton<_i35.BuildingsProvider>(
      _i35.BuildingsProvider(get<_i33.BuildingRepository>()));
  gh.singleton<_i67.ConstructedBuildingsProvider>(
      _i67.ConstructedBuildingsProvider(get<_i36.BuiltBuildingRepository>()));
  gh.singleton<_i51.ResourceProvider>(
      _i51.ResourceProvider(get<_i21.ResourceRepository>()));
  gh.singleton<_i48.ResourceSnapshotProvider>(
      _i48.ResourceSnapshotProvider(get<_i22.ResourceSnapshotRepository>()));
  gh.singleton<_i60.StoredResourceProvider>(_i60.StoredResourceProvider(
      get<_i9.EventService>(),
      get<_i48.ResourceSnapshotProvider>(),
      get<_i14.SelectedColonizedStellarObjectProvider>()));
  gh.singleton<_i54.BuildingChainProvider>(
      _i54.BuildingChainProvider(get<_i32.BuildingChainRepository>()));
  gh.singleton<_i56.BuildingHub>(_i56.BuildingHub(
      get<_i9.EventService>(),
      get<_i27.ServerConnection>(),
      get<_i12.HttpHeaderProvider>(),
      get<_i54.BuildingChainProvider>(),
      get<_i67.ConstructedBuildingsProvider>()));
  gh.singleton<_i65.BuildingImageProvider>(
      _i65.BuildingImageProvider(get<_i33.BuildingRepository>()));
  return get;
}

class _$ServicesModule extends _i69.ServicesModule {}
