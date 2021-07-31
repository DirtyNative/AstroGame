// GENERATED CODE - DO NOT MODIFY BY HAND

// **************************************************************************
// InjectableConfigGenerator
// **************************************************************************

import 'package:dio/dio.dart' as _i15;
import 'package:get_it/get_it.dart' as _i1;
import 'package:injectable/injectable.dart' as _i2;
import 'package:logger/logger.dart' as _i17;

import '../communications/dtos/add_player_species_request.dart' as _i54;
import '../communications/hubs/building_hub.dart' as _i76;
import '../communications/interceptors/header_interceptor.dart' as _i3;
import '../communications/repositories/authorization_repository.dart' as _i41;
import '../communications/repositories/building_chain_repository.dart' as _i42;
import '../communications/repositories/building_repository.dart' as _i43;
import '../communications/repositories/finished_technology_repository.dart'
    as _i16;
import '../communications/repositories/image_respository.dart' as _i21;
import '../communications/repositories/perk_repository.dart' as _i25;
import '../communications/repositories/player_repository.dart' as _i27;
import '../communications/repositories/player_species_repository.dart' as _i28;
import '../communications/repositories/research_repository.dart' as _i29;
import '../communications/repositories/research_study_repository.dart' as _i30;
import '../communications/repositories/resource_repository.dart' as _i31;
import '../communications/repositories/resource_snapshot_repository.dart'
    as _i32;
import '../communications/repositories/solar_system_repository.dart' as _i35;
import '../communications/repositories/species_repository.dart' as _i36;
import '../communications/repositories/stellar_object_repository.dart' as _i38;
import '../communications/repositories/stored_resource_repository.dart' as _i39;
import '../communications/repositories/technology_repository.dart' as _i40;
import '../communications/server_connection.dart' as _i22;
import '../executers/build_building_executer.dart' as _i73;
import '../executers/fetch_solar_system_executer.dart' as _i50;
import '../executers/login_executer.dart' as _i77;
import '../executers/set_players_species_executer.dart' as _i33;
import '../helpers/dialog_helper.dart' as _i34;
import '../helpers/resource_helper.dart' as _i12;
import '../models/buildings/building.dart' as _i68;
import '../models/buildings/building_construction.dart' as _i49;
import '../models/finished_technologies/finished_technology.dart' as _i9;
import '../models/players/colonized_stellar_object.dart' as _i47;
import '../models/researches/research.dart' as _i8;
import '../models/resources/resource.dart' as _i58;
import '../models/technologies/technology.dart' as _i66;
import '../models/technologies/technology_cost.dart' as _i59;
import '../providers/authorization_token_provider.dart' as _i19;
import '../providers/building_chain_provider.dart' as _i70;
import '../providers/buildings_provider.dart' as _i45;
import '../providers/constructed_buildings_provider.dart' as _i82;
import '../providers/fulfilled_conditions_provider.dart' as _i83;
import '../providers/http_header_provider.dart' as _i18;
import '../providers/image_provider.dart' as _i11;
import '../providers/player_provider.dart' as _i24;
import '../providers/research_provider.dart' as _i56;
import '../providers/research_study_provider.dart' as _i86;
import '../providers/resource_provider.dart' as _i63;
import '../providers/resource_snapshot_provider.dart' as _i60;
import '../providers/selected_colonized_stellar_object_provider.dart' as _i20;
import '../providers/solar_systems_provider.dart' as _i52;
import '../providers/stored_resource_provider.dart' as _i74;
import '../providers/studied_researches_provider.dart' as _i85;
import '../providers/technologies_provider.dart' as _i72;
import '../services/event_service.dart' as _i14;
import '../services/hub_service.dart' as _i75;
import '../services/local_storage_service.dart' as _i78;
import '../services/navigation_wrapper.dart' as _i10;
import '../views/building_detail/building_detail_viewmodel.dart' as _i67;
import '../views/buildings/buildings_viewmodel.dart' as _i44;
import '../views/common/resource_viewmodel.dart' as _i57;
import '../views/common/technology_cost_viewmodel.dart' as _i65;
import '../views/galaxy/galaxy_viewmodel.dart' as _i51;
import '../views/home/home_viewmodel.dart' as _i4;
import '../views/home/widgets/construction_viewmodel.dart' as _i48;
import '../views/home/widgets/constructions_viewmodel.dart' as _i69;
import '../views/login/login_viewmodel.dart' as _i79;
import '../views/market/market_viewmodel.dart' as _i5;
import '../views/menus/colony_viewmodel.dart' as _i46;
import '../views/menus/menu_viewmodel.dart' as _i23;
import '../views/menus/player_colonies_viewmodel.dart' as _i26;
import '../views/perk_selection/perk_selection_viewmodel.dart' as _i53;
import '../views/register/register_viewmodel.dart' as _i6;
import '../views/research_detail/research_detail_viewmodel.dart' as _i7;
import '../views/researches/researches_viewmodel.dart' as _i55;
import '../views/resources/resources_viewmodel.dart' as _i62;
import '../views/resources/widgets/resource_viewmodel.dart' as _i61;
import '../views/solar_system/solar_system_viewmodel.dart' as _i13;
import '../views/species_selection/species_selection_viewmodel.dart' as _i37;
import '../views/splash/splash_viewmodel.dart' as _i80;
import '../views/start/start_viewmodel.dart' as _i64;
import '../views/tech_tree/tech_tree_viewmodel.dart' as _i71;
import '../views/technologies/technology_card_viewmodel.dart' as _i81;
import 'device_info.dart' as _i84;
import 'services_module.dart' as _i87; // ignore_for_file: unnecessary_lambdas

// ignore_for_file: lines_longer_than_80_chars
/// initializes the registration of provided dependencies inside of [GetIt]
_i1.GetIt $initGetIt(_i1.GetIt get,
    {String? environment, _i2.EnvironmentFilter? environmentFilter}) {
  final gh = _i2.GetItHelper(get, environment, environmentFilter);
  final servicesModule = _$ServicesModule();
  gh.lazySingleton<_i3.HeaderInterceptor>(() => _i3.HeaderInterceptor());
  gh.factory<_i4.HomeViewModel>(() => _i4.HomeViewModel());
  gh.factory<_i5.MarketViewModel>(() => _i5.MarketViewModel());
  gh.factory<_i6.RegisterViewModel>(() => _i6.RegisterViewModel());
  gh.factoryParam<_i7.ResearchDetailViewModel, _i8.Research?,
          _i9.FinishedTechnology?>(
      (research, finishedTechnology) => _i7.ResearchDetailViewModel(
          get<_i10.NavigationWrapper>(),
          get<_i11.AssetImageProvider>(),
          research,
          finishedTechnology));
  gh.factory<_i12.ResourceHelper>(() => _i12.ResourceHelper());
  gh.factory<_i13.SolarSystemViewModel>(() => _i13.SolarSystemViewModel(
      get<_i14.EventService>(), get<_i10.NavigationWrapper>()));
  gh.factory<_i15.Dio>(() => servicesModule.dio(get<_i3.HeaderInterceptor>()));
  gh.factory<_i16.FinishedTechnologyRepository>(() =>
      _i16.FinishedTechnologyRepository(get<_i15.Dio>(), get<_i17.Logger>()));
  gh.factory<_i18.HttpHeaderProvider>(() => _i18.HttpHeaderProvider(
      get<_i19.AuthorizationTokenProvider>(),
      get<_i20.SelectedColonizedStellarObjectProvider>()));
  gh.factory<_i21.ImageRepository>(() => _i21.ImageRepository(
      get<_i15.Dio>(),
      get<_i17.Logger>(),
      get<_i22.ServerConnection>(),
      get<_i18.HttpHeaderProvider>()));
  gh.factory<_i23.MenuViewModel>(() => _i23.MenuViewModel(
      get<_i10.NavigationWrapper>(),
      get<_i24.PlayerProvider>(),
      get<_i11.AssetImageProvider>()));
  gh.factory<_i25.PerkRepository>(
      () => _i25.PerkRepository(get<_i15.Dio>(), get<_i17.Logger>()));
  gh.factory<_i26.PlayerColoniesViewModel>(
      () => _i26.PlayerColoniesViewModel(get<_i24.PlayerProvider>()));
  gh.factory<_i27.PlayerRepository>(
      () => _i27.PlayerRepository(get<_i15.Dio>(), get<_i17.Logger>()));
  gh.factory<_i28.PlayerSpeciesRepository>(
      () => _i28.PlayerSpeciesRepository(get<_i15.Dio>(), get<_i17.Logger>()));
  gh.factory<_i29.ResearchRepository>(() => _i29.ResearchRepository(
      get<_i15.Dio>(),
      get<_i17.Logger>(),
      get<_i22.ServerConnection>(),
      get<_i18.HttpHeaderProvider>()));
  gh.factory<_i30.ResearchStudyRepository>(
      () => _i30.ResearchStudyRepository(get<_i15.Dio>(), get<_i17.Logger>()));
  gh.factory<_i31.ResourceRepository>(
      () => _i31.ResourceRepository(get<_i15.Dio>(), get<_i17.Logger>()));
  gh.factory<_i32.ResourceSnapshotRepository>(() =>
      _i32.ResourceSnapshotRepository(get<_i15.Dio>(), get<_i17.Logger>()));
  gh.factory<_i33.SetPlayersSpeciesExecuter>(() =>
      _i33.SetPlayersSpeciesExecuter(
          get<_i27.PlayerRepository>(),
          get<_i28.PlayerSpeciesRepository>(),
          get<_i24.PlayerProvider>(),
          get<_i34.DialogHelper>(),
          get<_i10.NavigationWrapper>()));
  gh.factory<_i35.SolarSystemRepository>(
      () => _i35.SolarSystemRepository(get<_i15.Dio>(), get<_i17.Logger>()));
  gh.factory<_i36.SpeciesRepository>(
      () => _i36.SpeciesRepository(get<_i15.Dio>(), get<_i17.Logger>()));
  gh.factory<_i37.SpeciesSelectionViewModel>(() =>
      _i37.SpeciesSelectionViewModel(get<_i10.NavigationWrapper>(),
          get<_i36.SpeciesRepository>(), get<_i11.AssetImageProvider>()));
  gh.factory<_i38.StellarObjectRepository>(() => _i38.StellarObjectRepository(
      get<_i15.Dio>(), get<_i17.Logger>(), get<_i22.ServerConnection>()));
  gh.factory<_i39.StoredResourceRepository>(
      () => _i39.StoredResourceRepository(get<_i15.Dio>(), get<_i17.Logger>()));
  gh.factory<_i40.TechnologyRepository>(
      () => _i40.TechnologyRepository(get<_i15.Dio>(), get<_i17.Logger>()));
  gh.factory<_i41.AuthorizationRepository>(
      () => _i41.AuthorizationRepository(get<_i15.Dio>(), get<_i17.Logger>()));
  gh.factory<_i42.BuildingChainRepository>(
      () => _i42.BuildingChainRepository(get<_i15.Dio>(), get<_i17.Logger>()));
  gh.factory<_i43.BuildingRepository>(() => _i43.BuildingRepository(
      get<_i15.Dio>(),
      get<_i17.Logger>(),
      get<_i22.ServerConnection>(),
      get<_i18.HttpHeaderProvider>()));
  gh.factory<_i44.BuildingsViewModel>(
      () => _i44.BuildingsViewModel(get<_i45.BuildingsProvider>()));
  gh.factoryParam<_i46.ColonyViewModel, _i47.ColonizedStellarObject?, dynamic>(
      (colonizedStellarObject, _) => _i46.ColonyViewModel(
          get<_i20.SelectedColonizedStellarObjectProvider>(),
          get<_i38.StellarObjectRepository>(),
          get<_i11.AssetImageProvider>(),
          colonizedStellarObject));
  gh.factoryParam<_i48.ConstructionViewModel, _i49.BuildingConstruction?,
          dynamic>(
      (_buildingConstruction, _) => _i48.ConstructionViewModel(
          get<_i38.StellarObjectRepository>(),
          get<_i20.SelectedColonizedStellarObjectProvider>(),
          get<_i11.AssetImageProvider>(),
          _buildingConstruction));
  gh.factory<_i50.FetchSolarSystemExecuter>(() => _i50.FetchSolarSystemExecuter(
      get<_i34.DialogHelper>(), get<_i35.SolarSystemRepository>()));
  gh.factory<_i51.GalaxyViewModel>(
      () => _i51.GalaxyViewModel(get<_i52.SolarSystemsProvider>()));
  gh.factoryParam<_i53.PerkSelectionViewModel, _i54.AddPlayerSpeciesRequest?,
          dynamic>(
      (_playerSpecies, _) => _i53.PerkSelectionViewModel(
          get<_i25.PerkRepository>(),
          get<_i33.SetPlayersSpeciesExecuter>(),
          _playerSpecies));
  gh.factory<_i55.ResearchesViewModel>(
      () => _i55.ResearchesViewModel(get<_i56.ResearchProvider>()));
  gh.factoryParam<_i57.ResourceViewModel, _i58.Resource?, _i59.TechnologyCost?>(
      (_resource, _technologyCost) => _i57.ResourceViewModel(
          get<_i14.EventService>(),
          get<_i60.ResourceSnapshotProvider>(),
          _resource,
          _technologyCost));
  gh.factoryParam<_i61.ResourceViewModel, _i58.Resource?, dynamic>(
      (resource, _) => _i61.ResourceViewModel(get<_i14.EventService>(),
          get<_i60.ResourceSnapshotProvider>(), resource));
  gh.factory<_i62.ResourcesViewModel>(
      () => _i62.ResourcesViewModel(get<_i63.ResourceProvider>()));
  gh.factory<_i64.StartViewModel>(() => _i64.StartViewModel(
      get<_i50.FetchSolarSystemExecuter>(), get<_i14.EventService>()));
  gh.factoryParam<_i65.TechnologyCostViewModel, _i66.Technology?,
          _i9.FinishedTechnology?>(
      (technology, finishedTechnology) => _i65.TechnologyCostViewModel(
          get<_i40.TechnologyRepository>(),
          get<_i63.ResourceProvider>(),
          technology,
          finishedTechnology));
  gh.factoryParam<_i67.BuildingDetailViewModel, _i68.Building?,
          _i9.FinishedTechnology?>(
      (building, finishedTechnology) => _i67.BuildingDetailViewModel(
          get<_i40.TechnologyRepository>(),
          get<_i63.ResourceProvider>(),
          get<_i11.AssetImageProvider>(),
          building,
          finishedTechnology));
  gh.factory<_i69.ConstructionsViewModel>(() => _i69.ConstructionsViewModel(
      get<_i70.BuildingChainProvider>(), get<_i14.EventService>()));
  gh.factoryParam<_i71.TechTreeViewModel, _i66.Technology?, dynamic>(
      (_technology, _) => _i71.TechTreeViewModel(
          get<_i72.TechnologiesProvider>(), _technology));
  gh.factory<_i73.BuildBuildingExecuter>(() => _i73.BuildBuildingExecuter(
      get<_i14.EventService>(),
      get<_i34.DialogHelper>(),
      get<_i43.BuildingRepository>(),
      get<_i70.BuildingChainProvider>(),
      get<_i74.StoredResourceProvider>()));
  gh.factory<_i75.HubService>(() => _i75.HubService(get<_i76.TechnologyHub>()));
  gh.factory<_i77.LoginExecuter>(() => _i77.LoginExecuter(
      get<_i41.AuthorizationRepository>(),
      get<_i27.PlayerRepository>(),
      get<_i19.AuthorizationTokenProvider>(),
      get<_i24.PlayerProvider>(),
      get<_i34.DialogHelper>(),
      get<_i10.NavigationWrapper>(),
      get<_i75.HubService>(),
      get<_i78.LocalStorageService>()));
  gh.factoryParam<_i79.LoginViewModel, String?, dynamic>((lastEmail, _) =>
      _i79.LoginViewModel(
          get<_i77.LoginExecuter>(), get<_i10.NavigationWrapper>(), lastEmail));
  gh.factory<_i80.SplashViewModel>(() => _i80.SplashViewModel(
      get<_i75.HubService>(),
      get<_i78.LocalStorageService>(),
      get<_i10.NavigationWrapper>(),
      get<_i24.PlayerProvider>(),
      get<_i27.PlayerRepository>(),
      get<_i19.AuthorizationTokenProvider>()));
  gh.factoryParam<_i81.TechnologyCardViewModel, _i66.Technology?, dynamic>(
      (technology, _) => _i81.TechnologyCardViewModel(
          get<_i10.NavigationWrapper>(),
          get<_i70.BuildingChainProvider>(),
          get<_i82.ConstructedBuildingsProvider>(),
          get<_i11.AssetImageProvider>(),
          get<_i74.StoredResourceProvider>(),
          get<_i83.FulfilledConditionsProvider>(),
          get<_i73.BuildBuildingExecuter>(),
          get<_i14.EventService>(),
          get<_i12.ResourceHelper>(),
          technology));
  gh.singleton<_i11.AssetImageProvider>(_i11.AssetImageProvider());
  gh.singleton<_i19.AuthorizationTokenProvider>(
      _i19.AuthorizationTokenProvider());
  gh.singletonAsync<_i84.DeviceInfo>(() => _i84.DeviceInfo.instance());
  gh.singleton<_i14.EventService>(_i14.EventService());
  gh.singleton<_i78.LocalStorageService>(_i78.LocalStorageService());
  gh.singleton<_i17.Logger>(servicesModule.logger);
  gh.singleton<_i10.NavigationWrapper>(_i10.NavigationWrapper());
  gh.singleton<_i24.PlayerProvider>(_i24.PlayerProvider());
  gh.singleton<_i20.SelectedColonizedStellarObjectProvider>(
      _i20.SelectedColonizedStellarObjectProvider(get<_i24.PlayerProvider>()));
  gh.singleton<_i22.ServerConnection>(_i22.ServerConnection());
  gh.singleton<_i34.DialogHelper>(
      _i34.DialogHelper(get<_i10.NavigationWrapper>()));
  gh.singleton<_i52.SolarSystemsProvider>(
      _i52.SolarSystemsProvider(get<_i35.SolarSystemRepository>()));
  gh.singleton<_i85.StudiedResearchesProvider>(
      _i85.StudiedResearchesProvider(get<_i16.FinishedTechnologyRepository>()));
  gh.singleton<_i45.BuildingsProvider>(
      _i45.BuildingsProvider(get<_i43.BuildingRepository>()));
  gh.singleton<_i82.ConstructedBuildingsProvider>(
      _i82.ConstructedBuildingsProvider(
          get<_i16.FinishedTechnologyRepository>()));
  gh.singleton<_i83.FulfilledConditionsProvider>(
      _i83.FulfilledConditionsProvider(get<_i40.TechnologyRepository>()));
  gh.singleton<_i56.ResearchProvider>(
      _i56.ResearchProvider(get<_i29.ResearchRepository>()));
  gh.singleton<_i86.ResearchStudyProvider>(
      _i86.ResearchStudyProvider(get<_i30.ResearchStudyRepository>()));
  gh.singleton<_i63.ResourceProvider>(
      _i63.ResourceProvider(get<_i31.ResourceRepository>()));
  gh.singleton<_i60.ResourceSnapshotProvider>(_i60.ResourceSnapshotProvider(
      get<_i32.ResourceSnapshotRepository>(),
      get<_i20.SelectedColonizedStellarObjectProvider>()));
  gh.singleton<_i74.StoredResourceProvider>(_i74.StoredResourceProvider(
      get<_i14.EventService>(),
      get<_i60.ResourceSnapshotProvider>(),
      get<_i20.SelectedColonizedStellarObjectProvider>()));
  gh.singleton<_i72.TechnologiesProvider>(
      _i72.TechnologiesProvider(get<_i40.TechnologyRepository>()));
  gh.singleton<_i70.BuildingChainProvider>(_i70.BuildingChainProvider(
      get<_i42.BuildingChainRepository>(),
      get<_i20.SelectedColonizedStellarObjectProvider>()));
  gh.singleton<_i76.TechnologyHub>(_i76.TechnologyHub(
      get<_i14.EventService>(),
      get<_i70.BuildingChainProvider>(),
      get<_i82.ConstructedBuildingsProvider>(),
      get<_i74.StoredResourceProvider>(),
      get<_i22.ServerConnection>(),
      get<_i18.HttpHeaderProvider>()));
  return get;
}

class _$ServicesModule extends _i87.ServicesModule {}
