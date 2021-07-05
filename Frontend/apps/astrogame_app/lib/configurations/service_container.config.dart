// GENERATED CODE - DO NOT MODIFY BY HAND

// **************************************************************************
// InjectableConfigGenerator
// **************************************************************************

import 'package:dio/dio.dart' as _i12;
import 'package:get_it/get_it.dart' as _i1;
import 'package:injectable/injectable.dart' as _i2;
import 'package:logger/logger.dart' as _i14;

import '../communications/dtos/add_player_species_request.dart' as _i51;
import '../communications/hubs/building_hub.dart' as _i73;
import '../communications/interceptors/header_interceptor.dart' as _i3;
import '../communications/repositories/authorization_repository.dart' as _i37;
import '../communications/repositories/building_chain_repository.dart' as _i38;
import '../communications/repositories/building_repository.dart' as _i39;
import '../communications/repositories/finished_technology_repository.dart'
    as _i13;
import '../communications/repositories/image_respository.dart' as _i18;
import '../communications/repositories/perk_repository.dart' as _i20;
import '../communications/repositories/player_repository.dart' as _i23;
import '../communications/repositories/player_species_repository.dart' as _i24;
import '../communications/repositories/research_repository.dart' as _i25;
import '../communications/repositories/research_study_repository.dart' as _i26;
import '../communications/repositories/resource_repository.dart' as _i27;
import '../communications/repositories/resource_snapshot_repository.dart'
    as _i28;
import '../communications/repositories/solar_system_repository.dart' as _i31;
import '../communications/repositories/species_repository.dart' as _i32;
import '../communications/repositories/stellar_object_repository.dart' as _i35;
import '../communications/repositories/stored_resource_repository.dart' as _i36;
import '../communications/server_connection.dart' as _i19;
import '../executers/build_building_executer.dart' as _i83;
import '../executers/fetch_solar_system_executer.dart' as _i46;
import '../executers/login_executer.dart' as _i74;
import '../executers/set_players_species_executer.dart' as _i29;
import '../helpers/dialog_helper.dart' as _i30;
import '../helpers/resource_helper.dart' as _i7;
import '../models/buildings/building.dart' as _i69;
import '../models/buildings/building_construction.dart' as _i45;
import '../models/players/colonized_stellar_object.dart' as _i43;
import '../models/researches/research.dart' as _i53;
import '../models/resources/resource.dart' as _i58;
import '../models/technologies/finished_technology.dart' as _i54;
import '../models/technologies/technology.dart' as _i67;
import '../models/technologies/technology_cost.dart' as _i59;
import '../providers/authorization_token_provider.dart' as _i16;
import '../providers/building_chain_provider.dart' as _i71;
import '../providers/buildings_provider.dart' as _i41;
import '../providers/constructed_buildings_provider.dart' as _i85;
import '../providers/http_header_provider.dart' as _i15;
import '../providers/image_provider.dart' as _i34;
import '../providers/player_provider.dart' as _i22;
import '../providers/research_provider.dart' as _i56;
import '../providers/research_study_provider.dart' as _i80;
import '../providers/resource_provider.dart' as _i64;
import '../providers/resource_snapshot_provider.dart' as _i60;
import '../providers/selected_colonized_stellar_object_provider.dart' as _i17;
import '../providers/solar_systems_provider.dart' as _i48;
import '../providers/stored_resource_provider.dart' as _i79;
import '../providers/studied_researches_provider.dart' as _i78;
import '../services/event_service.dart' as _i9;
import '../services/hub_service.dart' as _i72;
import '../services/local_storage_service.dart' as _i75;
import '../services/navigation_wrapper.dart' as _i10;
import '../views/building_detail/building_detail_viewmodel.dart' as _i68;
import '../views/building_detail/widgets/resource_viewmodel.dart' as _i57;
import '../views/buildings/buildings_viewmodel.dart' as _i40;
import '../views/buildings/widgets/building_viewmodel.dart' as _i84;
import '../views/galaxy/galaxy_viewmodel.dart' as _i47;
import '../views/home/home_viewmodel.dart' as _i4;
import '../views/home/widgets/construction_viewmodel.dart' as _i44;
import '../views/home/widgets/constructions_viewmodel.dart' as _i70;
import '../views/login/login_viewmodel.dart' as _i76;
import '../views/market/market_viewmodel.dart' as _i5;
import '../views/menus/colony_viewmodel.dart' as _i42;
import '../views/menus/menu_viewmodel.dart' as _i49;
import '../views/menus/player_colonies_viewmodel.dart' as _i21;
import '../views/menus/resource_viewmodel.dart' as _i81;
import '../views/perk_selection/perk_selection_viewmodel.dart' as _i50;
import '../views/register/register_viewmodel.dart' as _i6;
import '../views/research_detail/research_detail_viewmodel.dart' as _i52;
import '../views/research_detail/widgets/resource_viewmodel.dart' as _i61;
import '../views/research_detail/widgets/tech_tree_viewmodel.dart' as _i11;
import '../views/research_detail/widgets/technology_cost_viewmodel.dart'
    as _i66;
import '../views/researches/researches_viewmodel.dart' as _i55;
import '../views/researches/widgets/research_viewmodel.dart' as _i77;
import '../views/resources/resources_viewmodel.dart' as _i63;
import '../views/resources/widgets/resource_viewmodel.dart' as _i62;
import '../views/solar_system/solar_system_viewmodel.dart' as _i8;
import '../views/species_selection/species_selection_viewmodel.dart' as _i33;
import '../views/splash/splash_viewmodel.dart' as _i82;
import '../views/start/start_viewmodel.dart' as _i65;
import 'device_info.dart' as _i86;
import 'services_module.dart' as _i87; // ignore_for_file: unnecessary_lambdas

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
  gh.factory<_i11.TechTreeViewModel>(() => _i11.TechTreeViewModel());
  gh.factory<_i12.Dio>(() => servicesModule.dio(get<_i3.HeaderInterceptor>()));
  gh.factory<_i13.FinishedTechnologyRepository>(() =>
      _i13.FinishedTechnologyRepository(get<_i12.Dio>(), get<_i14.Logger>()));
  gh.factory<_i15.HttpHeaderProvider>(() => _i15.HttpHeaderProvider(
      get<_i16.AuthorizationTokenProvider>(),
      get<_i17.SelectedColonizedStellarObjectProvider>()));
  gh.factory<_i18.ImageRepository>(() => _i18.ImageRepository(
      get<_i12.Dio>(),
      get<_i14.Logger>(),
      get<_i19.ServerConnection>(),
      get<_i15.HttpHeaderProvider>()));
  gh.factory<_i20.PerkRepository>(
      () => _i20.PerkRepository(get<_i12.Dio>(), get<_i14.Logger>()));
  gh.factory<_i21.PlayerColoniesViewModel>(
      () => _i21.PlayerColoniesViewModel(get<_i22.PlayerProvider>()));
  gh.factory<_i23.PlayerRepository>(
      () => _i23.PlayerRepository(get<_i12.Dio>(), get<_i14.Logger>()));
  gh.factory<_i24.PlayerSpeciesRepository>(
      () => _i24.PlayerSpeciesRepository(get<_i12.Dio>(), get<_i14.Logger>()));
  gh.factory<_i25.ResearchRepository>(() => _i25.ResearchRepository(
      get<_i12.Dio>(),
      get<_i14.Logger>(),
      get<_i19.ServerConnection>(),
      get<_i15.HttpHeaderProvider>()));
  gh.factory<_i26.ResearchStudyRepository>(
      () => _i26.ResearchStudyRepository(get<_i12.Dio>(), get<_i14.Logger>()));
  gh.factory<_i27.ResourceRepository>(
      () => _i27.ResourceRepository(get<_i12.Dio>(), get<_i14.Logger>()));
  gh.factory<_i28.ResourceSnapshotRepository>(() =>
      _i28.ResourceSnapshotRepository(get<_i12.Dio>(), get<_i14.Logger>()));
  gh.factory<_i29.SetPlayersSpeciesExecuter>(() =>
      _i29.SetPlayersSpeciesExecuter(
          get<_i23.PlayerRepository>(),
          get<_i24.PlayerSpeciesRepository>(),
          get<_i22.PlayerProvider>(),
          get<_i30.DialogHelper>(),
          get<_i10.NavigationWrapper>()));
  gh.factory<_i31.SolarSystemRepository>(
      () => _i31.SolarSystemRepository(get<_i12.Dio>(), get<_i14.Logger>()));
  gh.factory<_i32.SpeciesRepository>(
      () => _i32.SpeciesRepository(get<_i12.Dio>(), get<_i14.Logger>()));
  gh.factory<_i33.SpeciesSelectionViewModel>(() =>
      _i33.SpeciesSelectionViewModel(get<_i10.NavigationWrapper>(),
          get<_i32.SpeciesRepository>(), get<_i34.SpeciesImageProvider>()));
  gh.factory<_i35.StellarObjectRepository>(() => _i35.StellarObjectRepository(
      get<_i12.Dio>(), get<_i14.Logger>(), get<_i19.ServerConnection>()));
  gh.factory<_i36.StoredResourceRepository>(
      () => _i36.StoredResourceRepository(get<_i12.Dio>(), get<_i14.Logger>()));
  gh.factory<_i37.AuthorizationRepository>(
      () => _i37.AuthorizationRepository(get<_i12.Dio>(), get<_i14.Logger>()));
  gh.factory<_i38.BuildingChainRepository>(
      () => _i38.BuildingChainRepository(get<_i12.Dio>(), get<_i14.Logger>()));
  gh.factory<_i39.BuildingRepository>(() => _i39.BuildingRepository(
      get<_i12.Dio>(),
      get<_i14.Logger>(),
      get<_i19.ServerConnection>(),
      get<_i15.HttpHeaderProvider>()));
  gh.factory<_i40.BuildingsViewModel>(
      () => _i40.BuildingsViewModel(get<_i41.BuildingsProvider>()));
  gh.factoryParam<_i42.ColonyViewModel, _i43.ColonizedStellarObject, dynamic>(
      (colonizedStellarObject, _) => _i42.ColonyViewModel(
          get<_i17.SelectedColonizedStellarObjectProvider>(),
          get<_i35.StellarObjectRepository>(),
          colonizedStellarObject));
  gh.factoryParam<_i44.ConstructionViewModel, _i45.BuildingConstruction,
          dynamic>(
      (_buildingConstruction, _) => _i44.ConstructionViewModel(
          get<_i35.StellarObjectRepository>(),
          get<_i17.SelectedColonizedStellarObjectProvider>(),
          _buildingConstruction));
  gh.factory<_i46.FetchSolarSystemExecuter>(() => _i46.FetchSolarSystemExecuter(
      get<_i30.DialogHelper>(), get<_i31.SolarSystemRepository>()));
  gh.factory<_i47.GalaxyViewModel>(
      () => _i47.GalaxyViewModel(get<_i48.SolarSystemsProvider>()));
  gh.factory<_i49.MenuViewModel>(() => _i49.MenuViewModel(
      get<_i10.NavigationWrapper>(),
      get<_i22.PlayerProvider>(),
      get<_i34.SpeciesImageProvider>()));
  gh.factoryParam<_i50.PerkSelectionViewModel, _i51.AddPlayerSpeciesRequest,
          dynamic>(
      (_playerSpecies, _) => _i50.PerkSelectionViewModel(
          get<_i20.PerkRepository>(),
          get<_i29.SetPlayersSpeciesExecuter>(),
          _playerSpecies));
  gh.factoryParam<_i52.ResearchDetailViewModel, _i53.Research,
          _i54.FinishedTechnology>(
      (research, finishedTechnology) => _i52.ResearchDetailViewModel(
          get<_i34.ResearchImageProvider>(), research, finishedTechnology));
  gh.factory<_i55.ResearchesViewModel>(
      () => _i55.ResearchesViewModel(get<_i56.ResearchProvider>()));
  gh.factoryParam<_i57.ResourceViewModel, _i58.Resource, _i59.TechnologyCost>(
      (_resource, _technologyCost) => _i57.ResourceViewModel(
          get<_i9.EventService>(),
          get<_i60.ResourceSnapshotProvider>(),
          get<_i17.SelectedColonizedStellarObjectProvider>(),
          _resource,
          _technologyCost));
  gh.factoryParam<_i61.ResourceViewModel, _i58.Resource, _i59.TechnologyCost>(
      (_resource, _technologyCost) => _i61.ResourceViewModel(
          get<_i9.EventService>(),
          get<_i60.ResourceSnapshotProvider>(),
          get<_i17.SelectedColonizedStellarObjectProvider>(),
          _resource,
          _technologyCost));
  gh.factoryParam<_i62.ResourceViewModel, _i58.Resource, dynamic>(
      (_resource, _) => _i62.ResourceViewModel(
          get<_i9.EventService>(),
          get<_i60.ResourceSnapshotProvider>(),
          get<_i17.SelectedColonizedStellarObjectProvider>(),
          _resource));
  gh.factory<_i63.ResourcesViewModel>(
      () => _i63.ResourcesViewModel(get<_i64.ResourceProvider>()));
  gh.factory<_i65.StartViewModel>(() => _i65.StartViewModel(
      get<_i46.FetchSolarSystemExecuter>(), get<_i9.EventService>()));
  gh.factoryParam<_i66.TechnologyCostViewModel, _i67.Technology,
          _i54.FinishedTechnology>(
      (research, finishedTechnology) => _i66.TechnologyCostViewModel(
          get<_i25.ResearchRepository>(),
          get<_i64.ResourceProvider>(),
          research,
          finishedTechnology));
  gh.factoryParam<_i68.BuildingDetailViewModel, _i69.Building,
          _i54.FinishedTechnology>(
      (building, finishedTechnology) => _i68.BuildingDetailViewModel(
          get<_i39.BuildingRepository>(),
          get<_i64.ResourceProvider>(),
          get<_i34.BuildingImageProvider>(),
          building,
          finishedTechnology));
  gh.factory<_i70.ConstructionsViewModel>(() => _i70.ConstructionsViewModel(
      get<_i71.BuildingChainProvider>(), get<_i9.EventService>()));
  gh.factory<_i72.HubService>(() => _i72.HubService(get<_i73.BuildingHub>()));
  gh.factory<_i74.LoginExecuter>(() => _i74.LoginExecuter(
      get<_i37.AuthorizationRepository>(),
      get<_i23.PlayerRepository>(),
      get<_i16.AuthorizationTokenProvider>(),
      get<_i22.PlayerProvider>(),
      get<_i30.DialogHelper>(),
      get<_i10.NavigationWrapper>(),
      get<_i72.HubService>(),
      get<_i75.LocalStorageService>()));
  gh.factoryParam<_i76.LoginViewModel, String, dynamic>((lastEmail, _) =>
      _i76.LoginViewModel(
          get<_i74.LoginExecuter>(), get<_i10.NavigationWrapper>(), lastEmail));
  gh.factoryParam<_i77.ResearchViewModel, _i53.Research, dynamic>(
      (_research, _) => _i77.ResearchViewModel(
          get<_i10.NavigationWrapper>(),
          get<_i78.StudiedResearchesProvider>(),
          get<_i34.ResearchImageProvider>(),
          get<_i79.StoredResourceProvider>(),
          get<_i80.ResearchStudyProvider>(),
          get<_i9.EventService>(),
          get<_i7.ResourceHelper>(),
          _research));
  gh.factory<_i81.ResourceViewModel>(() => _i81.ResourceViewModel(
      get<_i9.EventService>(),
      get<_i64.ResourceProvider>(),
      get<_i79.StoredResourceProvider>()));
  gh.factory<_i82.SplashViewModel>(() => _i82.SplashViewModel(
      get<_i72.HubService>(),
      get<_i75.LocalStorageService>(),
      get<_i10.NavigationWrapper>(),
      get<_i22.PlayerProvider>(),
      get<_i23.PlayerRepository>(),
      get<_i16.AuthorizationTokenProvider>()));
  gh.factory<_i83.BuildBuildingExecuter>(() => _i83.BuildBuildingExecuter(
      get<_i9.EventService>(),
      get<_i30.DialogHelper>(),
      get<_i39.BuildingRepository>(),
      get<_i71.BuildingChainProvider>(),
      get<_i79.StoredResourceProvider>()));
  gh.factoryParam<_i84.BuildingViewModel, _i69.Building, dynamic>(
      (_building, _) => _i84.BuildingViewModel(
          get<_i10.NavigationWrapper>(),
          get<_i71.BuildingChainProvider>(),
          get<_i85.ConstructedBuildingsProvider>(),
          get<_i17.SelectedColonizedStellarObjectProvider>(),
          get<_i34.BuildingImageProvider>(),
          get<_i79.StoredResourceProvider>(),
          get<_i83.BuildBuildingExecuter>(),
          get<_i9.EventService>(),
          get<_i7.ResourceHelper>(),
          _building));
  gh.singleton<_i16.AuthorizationTokenProvider>(
      _i16.AuthorizationTokenProvider());
  gh.singletonAsync<_i86.DeviceInfo>(() => _i86.DeviceInfo.instance());
  gh.singleton<_i9.EventService>(_i9.EventService());
  gh.singleton<_i75.LocalStorageService>(_i75.LocalStorageService());
  gh.singleton<_i14.Logger>(servicesModule.logger);
  gh.singleton<_i10.NavigationWrapper>(_i10.NavigationWrapper());
  gh.singleton<_i22.PlayerProvider>(_i22.PlayerProvider());
  gh.singleton<_i17.SelectedColonizedStellarObjectProvider>(
      _i17.SelectedColonizedStellarObjectProvider(get<_i22.PlayerProvider>()));
  gh.singleton<_i19.ServerConnection>(_i19.ServerConnection());
  gh.singleton<_i30.DialogHelper>(
      _i30.DialogHelper(get<_i10.NavigationWrapper>()));
  gh.singleton<_i34.ResearchImageProvider>(
      _i34.ResearchImageProvider(get<_i18.ImageRepository>()));
  gh.singleton<_i48.SolarSystemsProvider>(
      _i48.SolarSystemsProvider(get<_i31.SolarSystemRepository>()));
  gh.singleton<_i34.SpeciesImageProvider>(
      _i34.SpeciesImageProvider(get<_i18.ImageRepository>()));
  gh.singleton<_i34.StellarObjectImageProvider>(
      _i34.StellarObjectImageProvider(get<_i18.ImageRepository>()));
  gh.singleton<_i78.StudiedResearchesProvider>(
      _i78.StudiedResearchesProvider(get<_i13.FinishedTechnologyRepository>()));
  gh.singleton<_i34.BuildingImageProvider>(
      _i34.BuildingImageProvider(get<_i18.ImageRepository>()));
  gh.singleton<_i41.BuildingsProvider>(
      _i41.BuildingsProvider(get<_i39.BuildingRepository>()));
  gh.singleton<_i85.ConstructedBuildingsProvider>(
      _i85.ConstructedBuildingsProvider(
          get<_i13.FinishedTechnologyRepository>()));
  gh.singleton<_i56.ResearchProvider>(
      _i56.ResearchProvider(get<_i25.ResearchRepository>()));
  gh.singleton<_i80.ResearchStudyProvider>(
      _i80.ResearchStudyProvider(get<_i26.ResearchStudyRepository>()));
  gh.singleton<_i64.ResourceProvider>(
      _i64.ResourceProvider(get<_i27.ResourceRepository>()));
  gh.singleton<_i60.ResourceSnapshotProvider>(
      _i60.ResourceSnapshotProvider(get<_i28.ResourceSnapshotRepository>()));
  gh.singleton<_i79.StoredResourceProvider>(_i79.StoredResourceProvider(
      get<_i9.EventService>(),
      get<_i60.ResourceSnapshotProvider>(),
      get<_i17.SelectedColonizedStellarObjectProvider>()));
  gh.singleton<_i71.BuildingChainProvider>(
      _i71.BuildingChainProvider(get<_i38.BuildingChainRepository>()));
  gh.singleton<_i73.BuildingHub>(_i73.BuildingHub(
      get<_i9.EventService>(),
      get<_i19.ServerConnection>(),
      get<_i15.HttpHeaderProvider>(),
      get<_i71.BuildingChainProvider>(),
      get<_i85.ConstructedBuildingsProvider>()));
  return get;
}

class _$ServicesModule extends _i87.ServicesModule {}
