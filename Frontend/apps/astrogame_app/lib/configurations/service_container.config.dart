// GENERATED CODE - DO NOT MODIFY BY HAND

// **************************************************************************
// InjectableConfigGenerator
// **************************************************************************

import 'package:dio/dio.dart' as _i16;
import 'package:get_it/get_it.dart' as _i1;
import 'package:injectable/injectable.dart' as _i2;
import 'package:logger/logger.dart' as _i18;

import '../communications/dtos/add_player_species_request.dart' as _i59;
import '../communications/hubs/building_hub.dart' as _i86;
import '../communications/interceptors/header_interceptor.dart' as _i3;
import '../communications/repositories/authorization_repository.dart' as _i44;
import '../communications/repositories/building_chain_repository.dart' as _i45;
import '../communications/repositories/building_repository.dart' as _i46;
import '../communications/repositories/finished_technology_repository.dart'
    as _i17;
import '../communications/repositories/image_respository.dart' as _i22;
import '../communications/repositories/perk_repository.dart' as _i26;
import '../communications/repositories/player_repository.dart' as _i28;
import '../communications/repositories/player_species_repository.dart' as _i29;
import '../communications/repositories/research_repository.dart' as _i30;
import '../communications/repositories/research_study_repository.dart' as _i31;
import '../communications/repositories/resource_repository.dart' as _i32;
import '../communications/repositories/resource_snapshot_repository.dart'
    as _i33;
import '../communications/repositories/solar_system_repository.dart' as _i36;
import '../communications/repositories/species_repository.dart' as _i37;
import '../communications/repositories/stellar_object_repository.dart' as _i41;
import '../communications/repositories/stored_resource_repository.dart' as _i42;
import '../communications/repositories/technology_repository.dart' as _i43;
import '../communications/server_connection.dart' as _i23;
import '../executers/build_building_executer.dart' as _i78;
import '../executers/fetch_solar_system_executer.dart' as _i53;
import '../executers/login_executer.dart' as _i56;
import '../executers/set_players_species_executer.dart' as _i34;
import '../helpers/dialog_helper.dart' as _i35;
import '../helpers/resource_helper.dart' as _i13;
import '../models/buildings/building.dart' as _i73;
import '../models/buildings/building_construction.dart' as _i52;
import '../models/finished_technologies/finished_technology.dart' as _i10;
import '../models/players/colonized_stellar_object.dart' as _i50;
import '../models/researches/research.dart' as _i9;
import '../models/resources/resource.dart' as _i63;
import '../models/technologies/technology.dart' as _i71;
import '../models/technologies/technology_cost.dart' as _i64;
import '../providers/authorization_token_provider.dart' as _i20;
import '../providers/building_chain_provider.dart' as _i75;
import '../providers/buildings_provider.dart' as _i48;
import '../providers/constructed_buildings_provider.dart' as _i81;
import '../providers/fulfilled_conditions_provider.dart' as _i82;
import '../providers/http_header_provider.dart' as _i19;
import '../providers/image_provider.dart' as _i12;
import '../providers/player_provider.dart' as _i25;
import '../providers/research_provider.dart' as _i61;
import '../providers/research_study_provider.dart' as _i85;
import '../providers/resource_provider.dart' as _i68;
import '../providers/resource_snapshot_provider.dart' as _i65;
import '../providers/selected_colonized_stellar_object_provider.dart' as _i21;
import '../providers/solar_systems_provider.dart' as _i55;
import '../providers/stored_resource_provider.dart' as _i79;
import '../providers/studied_researches_provider.dart' as _i84;
import '../providers/technologies_provider.dart' as _i77;
import '../services/event_service.dart' as _i15;
import '../services/hub_service.dart' as _i5;
import '../services/local_storage_service.dart' as _i40;
import '../services/navigation_wrapper.dart' as _i11;
import '../views/building_detail/building_detail_viewmodel.dart' as _i72;
import '../views/buildings/buildings_viewmodel.dart' as _i47;
import '../views/common/resource_viewmodel.dart' as _i62;
import '../views/common/technology_cost_viewmodel.dart' as _i70;
import '../views/galaxy/galaxy_viewmodel.dart' as _i54;
import '../views/home/home_viewmodel.dart' as _i4;
import '../views/home/widgets/construction_viewmodel.dart' as _i51;
import '../views/home/widgets/constructions_viewmodel.dart' as _i74;
import '../views/login/login_viewmodel.dart' as _i57;
import '../views/market/market_viewmodel.dart' as _i6;
import '../views/menus/colony_viewmodel.dart' as _i49;
import '../views/menus/menu_viewmodel.dart' as _i24;
import '../views/menus/player_colonies_viewmodel.dart' as _i27;
import '../views/perk_selection/perk_selection_viewmodel.dart' as _i58;
import '../views/register/register_viewmodel.dart' as _i7;
import '../views/research_detail/research_detail_viewmodel.dart' as _i8;
import '../views/researches/researches_viewmodel.dart' as _i60;
import '../views/resources/resources_viewmodel.dart' as _i67;
import '../views/resources/widgets/resource_viewmodel.dart' as _i66;
import '../views/solar_system/solar_system_viewmodel.dart' as _i14;
import '../views/species_selection/species_selection_viewmodel.dart' as _i38;
import '../views/splash/splash_viewmodel.dart' as _i39;
import '../views/start/start_viewmodel.dart' as _i69;
import '../views/tech_tree/tech_tree_viewmodel.dart' as _i76;
import '../views/technologies/technology_card_viewmodel.dart' as _i80;
import 'device_info.dart' as _i83;
import 'services_module.dart' as _i87; // ignore_for_file: unnecessary_lambdas

// ignore_for_file: lines_longer_than_80_chars
/// initializes the registration of provided dependencies inside of [GetIt]
_i1.GetIt $initGetIt(_i1.GetIt get,
    {String? environment, _i2.EnvironmentFilter? environmentFilter}) {
  final gh = _i2.GetItHelper(get, environment, environmentFilter);
  final servicesModule = _$ServicesModule();
  gh.lazySingleton<_i3.HeaderInterceptor>(() => _i3.HeaderInterceptor());
  gh.factory<_i4.HomeViewModel>(() => _i4.HomeViewModel());
  gh.factory<_i5.HubService>(() => _i5.HubService(get<dynamic>()));
  gh.factory<_i6.MarketViewModel>(() => _i6.MarketViewModel());
  gh.factory<_i7.RegisterViewModel>(() => _i7.RegisterViewModel());
  gh.factoryParam<_i8.ResearchDetailViewModel, _i9.Research?,
          _i10.FinishedTechnology?>(
      (research, finishedTechnology) => _i8.ResearchDetailViewModel(
          get<_i11.NavigationWrapper>(),
          get<_i12.AssetImageProvider>(),
          research,
          finishedTechnology));
  gh.factory<_i13.ResourceHelper>(() => _i13.ResourceHelper());
  gh.factory<_i14.SolarSystemViewModel>(() => _i14.SolarSystemViewModel(
      get<_i15.EventService>(), get<_i11.NavigationWrapper>()));
  gh.factory<_i16.Dio>(() => servicesModule.dio(get<_i3.HeaderInterceptor>()));
  gh.factory<_i17.FinishedTechnologyRepository>(() =>
      _i17.FinishedTechnologyRepository(get<_i16.Dio>(), get<_i18.Logger>()));
  gh.factory<_i19.HttpHeaderProvider>(() => _i19.HttpHeaderProvider(
      get<_i20.AuthorizationTokenProvider>(),
      get<_i21.SelectedColonizedStellarObjectProvider>()));
  gh.factory<_i22.ImageRepository>(() => _i22.ImageRepository(
      get<_i16.Dio>(),
      get<_i18.Logger>(),
      get<_i23.ServerConnection>(),
      get<_i19.HttpHeaderProvider>()));
  gh.factory<_i24.MenuViewModel>(() => _i24.MenuViewModel(
      get<_i11.NavigationWrapper>(),
      get<_i25.PlayerProvider>(),
      get<_i12.AssetImageProvider>()));
  gh.factory<_i26.PerkRepository>(
      () => _i26.PerkRepository(get<_i16.Dio>(), get<_i18.Logger>()));
  gh.factory<_i27.PlayerColoniesViewModel>(
      () => _i27.PlayerColoniesViewModel(get<_i25.PlayerProvider>()));
  gh.factory<_i28.PlayerRepository>(
      () => _i28.PlayerRepository(get<_i16.Dio>(), get<_i18.Logger>()));
  gh.factory<_i29.PlayerSpeciesRepository>(
      () => _i29.PlayerSpeciesRepository(get<_i16.Dio>(), get<_i18.Logger>()));
  gh.factory<_i30.ResearchRepository>(() => _i30.ResearchRepository(
      get<_i16.Dio>(),
      get<_i18.Logger>(),
      get<_i23.ServerConnection>(),
      get<_i19.HttpHeaderProvider>()));
  gh.factory<_i31.ResearchStudyRepository>(
      () => _i31.ResearchStudyRepository(get<_i16.Dio>(), get<_i18.Logger>()));
  gh.factory<_i32.ResourceRepository>(
      () => _i32.ResourceRepository(get<_i16.Dio>(), get<_i18.Logger>()));
  gh.factory<_i33.ResourceSnapshotRepository>(() =>
      _i33.ResourceSnapshotRepository(get<_i16.Dio>(), get<_i18.Logger>()));
  gh.factory<_i34.SetPlayersSpeciesExecuter>(() =>
      _i34.SetPlayersSpeciesExecuter(
          get<_i28.PlayerRepository>(),
          get<_i29.PlayerSpeciesRepository>(),
          get<_i25.PlayerProvider>(),
          get<_i35.DialogHelper>(),
          get<_i11.NavigationWrapper>()));
  gh.factory<_i36.SolarSystemRepository>(
      () => _i36.SolarSystemRepository(get<_i16.Dio>(), get<_i18.Logger>()));
  gh.factory<_i37.SpeciesRepository>(
      () => _i37.SpeciesRepository(get<_i16.Dio>(), get<_i18.Logger>()));
  gh.factory<_i38.SpeciesSelectionViewModel>(() =>
      _i38.SpeciesSelectionViewModel(get<_i11.NavigationWrapper>(),
          get<_i37.SpeciesRepository>(), get<_i12.AssetImageProvider>()));
  gh.factory<_i39.SplashViewModel>(() => _i39.SplashViewModel(
      get<_i5.HubService>(),
      get<_i40.LocalStorageService>(),
      get<_i11.NavigationWrapper>(),
      get<_i25.PlayerProvider>(),
      get<_i28.PlayerRepository>(),
      get<_i20.AuthorizationTokenProvider>()));
  gh.factory<_i41.StellarObjectRepository>(() => _i41.StellarObjectRepository(
      get<_i16.Dio>(), get<_i18.Logger>(), get<_i23.ServerConnection>()));
  gh.factory<_i42.StoredResourceRepository>(
      () => _i42.StoredResourceRepository(get<_i16.Dio>(), get<_i18.Logger>()));
  gh.factory<_i43.TechnologyRepository>(
      () => _i43.TechnologyRepository(get<_i16.Dio>(), get<_i18.Logger>()));
  gh.factory<_i44.AuthorizationRepository>(
      () => _i44.AuthorizationRepository(get<_i16.Dio>(), get<_i18.Logger>()));
  gh.factory<_i45.BuildingChainRepository>(
      () => _i45.BuildingChainRepository(get<_i16.Dio>(), get<_i18.Logger>()));
  gh.factory<_i46.BuildingRepository>(() => _i46.BuildingRepository(
      get<_i16.Dio>(),
      get<_i18.Logger>(),
      get<_i23.ServerConnection>(),
      get<_i19.HttpHeaderProvider>()));
  gh.factory<_i47.BuildingsViewModel>(
      () => _i47.BuildingsViewModel(get<_i48.BuildingsProvider>()));
  gh.factoryParam<_i49.ColonyViewModel, _i50.ColonizedStellarObject?, dynamic>(
      (colonizedStellarObject, _) => _i49.ColonyViewModel(
          get<_i21.SelectedColonizedStellarObjectProvider>(),
          get<_i41.StellarObjectRepository>(),
          get<_i12.AssetImageProvider>(),
          colonizedStellarObject));
  gh.factoryParam<_i51.ConstructionViewModel, _i52.BuildingConstruction?,
          dynamic>(
      (_buildingConstruction, _) => _i51.ConstructionViewModel(
          get<_i41.StellarObjectRepository>(),
          get<_i21.SelectedColonizedStellarObjectProvider>(),
          get<_i12.AssetImageProvider>(),
          _buildingConstruction));
  gh.factory<_i53.FetchSolarSystemExecuter>(() => _i53.FetchSolarSystemExecuter(
      get<_i35.DialogHelper>(), get<_i36.SolarSystemRepository>()));
  gh.factory<_i54.GalaxyViewModel>(
      () => _i54.GalaxyViewModel(get<_i55.SolarSystemsProvider>()));
  gh.factory<_i56.LoginExecuter>(() => _i56.LoginExecuter(
      get<_i44.AuthorizationRepository>(),
      get<_i28.PlayerRepository>(),
      get<_i20.AuthorizationTokenProvider>(),
      get<_i25.PlayerProvider>(),
      get<_i35.DialogHelper>(),
      get<_i11.NavigationWrapper>(),
      get<_i5.HubService>(),
      get<_i40.LocalStorageService>()));
  gh.factoryParam<_i57.LoginViewModel, String?, dynamic>((lastEmail, _) =>
      _i57.LoginViewModel(
          get<_i56.LoginExecuter>(), get<_i11.NavigationWrapper>(), lastEmail));
  gh.factoryParam<_i58.PerkSelectionViewModel, _i59.AddPlayerSpeciesRequest?,
          dynamic>(
      (_playerSpecies, _) => _i58.PerkSelectionViewModel(
          get<_i26.PerkRepository>(),
          get<_i34.SetPlayersSpeciesExecuter>(),
          _playerSpecies));
  gh.factory<_i60.ResearchesViewModel>(
      () => _i60.ResearchesViewModel(get<_i61.ResearchProvider>()));
  gh.factoryParam<_i62.ResourceViewModel, _i63.Resource?, _i64.TechnologyCost?>(
      (_resource, _technologyCost) => _i62.ResourceViewModel(
          get<_i15.EventService>(),
          get<_i65.ResourceSnapshotProvider>(),
          _resource,
          _technologyCost));
  gh.factoryParam<_i66.ResourceViewModel, _i63.Resource?, dynamic>(
      (resource, _) => _i66.ResourceViewModel(get<_i15.EventService>(),
          get<_i65.ResourceSnapshotProvider>(), resource));
  gh.factory<_i67.ResourcesViewModel>(
      () => _i67.ResourcesViewModel(get<_i68.ResourceProvider>()));
  gh.factory<_i69.StartViewModel>(() => _i69.StartViewModel(
      get<_i53.FetchSolarSystemExecuter>(), get<_i15.EventService>()));
  gh.factoryParam<_i70.TechnologyCostViewModel, _i71.Technology?,
          _i10.FinishedTechnology?>(
      (technology, finishedTechnology) => _i70.TechnologyCostViewModel(
          get<_i43.TechnologyRepository>(),
          get<_i68.ResourceProvider>(),
          technology,
          finishedTechnology));
  gh.factoryParam<_i72.BuildingDetailViewModel, _i73.Building?,
          _i10.FinishedTechnology?>(
      (building, finishedTechnology) => _i72.BuildingDetailViewModel(
          get<_i43.TechnologyRepository>(),
          get<_i68.ResourceProvider>(),
          get<_i12.AssetImageProvider>(),
          building,
          finishedTechnology));
  gh.factory<_i74.ConstructionsViewModel>(() => _i74.ConstructionsViewModel(
      get<_i75.BuildingChainProvider>(), get<_i15.EventService>()));
  gh.factoryParam<_i76.TechTreeViewModel, _i71.Technology?, dynamic>(
      (_technology, _) => _i76.TechTreeViewModel(
          get<_i77.TechnologiesProvider>(), _technology));
  gh.factory<_i78.BuildBuildingExecuter>(() => _i78.BuildBuildingExecuter(
      get<_i15.EventService>(),
      get<_i35.DialogHelper>(),
      get<_i46.BuildingRepository>(),
      get<_i75.BuildingChainProvider>(),
      get<_i79.StoredResourceProvider>()));
  gh.factoryParam<_i80.TechnologyCardViewModel, _i71.Technology?, dynamic>(
      (technology, _) => _i80.TechnologyCardViewModel(
          get<_i11.NavigationWrapper>(),
          get<_i75.BuildingChainProvider>(),
          get<_i81.ConstructedBuildingsProvider>(),
          get<_i12.AssetImageProvider>(),
          get<_i79.StoredResourceProvider>(),
          get<_i82.FulfilledConditionsProvider>(),
          get<_i78.BuildBuildingExecuter>(),
          get<_i15.EventService>(),
          get<_i13.ResourceHelper>(),
          technology));
  gh.singleton<_i12.AssetImageProvider>(_i12.AssetImageProvider());
  gh.singleton<_i20.AuthorizationTokenProvider>(
      _i20.AuthorizationTokenProvider());
  gh.singletonAsync<_i83.DeviceInfo>(() => _i83.DeviceInfo.instance());
  gh.singleton<_i15.EventService>(_i15.EventService());
  gh.singleton<_i40.LocalStorageService>(_i40.LocalStorageService());
  gh.singleton<_i18.Logger>(servicesModule.logger);
  gh.singleton<_i11.NavigationWrapper>(_i11.NavigationWrapper());
  gh.singleton<_i25.PlayerProvider>(_i25.PlayerProvider());
  gh.singleton<_i21.SelectedColonizedStellarObjectProvider>(
      _i21.SelectedColonizedStellarObjectProvider(get<_i25.PlayerProvider>()));
  gh.singleton<_i23.ServerConnection>(_i23.ServerConnection());
  gh.singleton<_i35.DialogHelper>(
      _i35.DialogHelper(get<_i11.NavigationWrapper>()));
  gh.singleton<_i55.SolarSystemsProvider>(
      _i55.SolarSystemsProvider(get<_i36.SolarSystemRepository>()));
  gh.singleton<_i84.StudiedResearchesProvider>(
      _i84.StudiedResearchesProvider(get<_i17.FinishedTechnologyRepository>()));
  gh.singleton<_i48.BuildingsProvider>(
      _i48.BuildingsProvider(get<_i46.BuildingRepository>()));
  gh.singleton<_i81.ConstructedBuildingsProvider>(
      _i81.ConstructedBuildingsProvider(
          get<_i17.FinishedTechnologyRepository>()));
  gh.singleton<_i82.FulfilledConditionsProvider>(
      _i82.FulfilledConditionsProvider(get<_i43.TechnologyRepository>()));
  gh.singleton<_i61.ResearchProvider>(
      _i61.ResearchProvider(get<_i30.ResearchRepository>()));
  gh.singleton<_i85.ResearchStudyProvider>(
      _i85.ResearchStudyProvider(get<_i31.ResearchStudyRepository>()));
  gh.singleton<_i68.ResourceProvider>(
      _i68.ResourceProvider(get<_i32.ResourceRepository>()));
  gh.singleton<_i65.ResourceSnapshotProvider>(_i65.ResourceSnapshotProvider(
      get<_i33.ResourceSnapshotRepository>(),
      get<_i21.SelectedColonizedStellarObjectProvider>()));
  gh.singleton<_i79.StoredResourceProvider>(_i79.StoredResourceProvider(
      get<_i15.EventService>(),
      get<_i65.ResourceSnapshotProvider>(),
      get<_i21.SelectedColonizedStellarObjectProvider>()));
  gh.singleton<_i77.TechnologiesProvider>(
      _i77.TechnologiesProvider(get<_i43.TechnologyRepository>()));
  gh.singleton<_i75.BuildingChainProvider>(_i75.BuildingChainProvider(
      get<_i45.BuildingChainRepository>(),
      get<_i21.SelectedColonizedStellarObjectProvider>()));
  gh.singleton<_i86.TechnologyHub>(_i86.TechnologyHub(
      get<_i15.EventService>(),
      get<_i75.BuildingChainProvider>(),
      get<_i81.ConstructedBuildingsProvider>(),
      get<_i79.StoredResourceProvider>(),
      get<_i23.ServerConnection>(),
      get<_i19.HttpHeaderProvider>()));
  return get;
}

class _$ServicesModule extends _i87.ServicesModule {}
