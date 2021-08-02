// GENERATED CODE - DO NOT MODIFY BY HAND

// **************************************************************************
// InjectableConfigGenerator
// **************************************************************************

import 'package:dio/dio.dart' as _i15;
import 'package:get_it/get_it.dart' as _i1;
import 'package:injectable/injectable.dart' as _i2;
import 'package:logger/logger.dart' as _i17;

import '../communications/dtos/add_player_species_request.dart' as _i55;
import '../communications/hubs/technology_hub.dart' as _i73;
import '../communications/interceptors/header_interceptor.dart' as _i3;
import '../communications/repositories/authorization_repository.dart' as _i41;
import '../communications/repositories/building_repository.dart' as _i42;
import '../communications/repositories/finished_technology_repository.dart'
    as _i16;
import '../communications/repositories/image_respository.dart' as _i21;
import '../communications/repositories/perk_repository.dart' as _i25;
import '../communications/repositories/player_repository.dart' as _i27;
import '../communications/repositories/player_species_repository.dart' as _i28;
import '../communications/repositories/research_repository.dart' as _i29;
import '../communications/repositories/resource_repository.dart' as _i30;
import '../communications/repositories/resource_snapshot_repository.dart'
    as _i31;
import '../communications/repositories/solar_system_repository.dart' as _i34;
import '../communications/repositories/species_repository.dart' as _i35;
import '../communications/repositories/stellar_object_repository.dart' as _i37;
import '../communications/repositories/stored_resource_repository.dart' as _i38;
import '../communications/repositories/technology_repository.dart' as _i39;
import '../communications/repositories/technology_upgrade_repository.dart'
    as _i40;
import '../communications/server_connection.dart' as _i22;
import '../executers/fetch_solar_system_executer.dart' as _i51;
import '../executers/login_executer.dart' as _i74;
import '../executers/set_players_species_executer.dart' as _i32;
import '../executers/upgrade_technology_executer.dart' as _i68;
import '../helpers/dialog_helper.dart' as _i33;
import '../helpers/resource_helper.dart' as _i12;
import '../models/buildings/building.dart' as _i71;
import '../models/finished_technologies/finished_technology.dart' as _i9;
import '../models/players/colonized_stellar_object.dart' as _i46;
import '../models/researches/research.dart' as _i8;
import '../models/resources/resource.dart' as _i59;
import '../models/technologies/stellar_object_dependent_technology_upgrade.dart'
    as _i48;
import '../models/technologies/technology.dart' as _i67;
import '../models/technologies/technology_cost.dart' as _i60;
import '../providers/authorization_token_provider.dart' as _i19;
import '../providers/buildings_provider.dart' as _i44;
import '../providers/finished_technologies_provider.dart' as _i81;
import '../providers/fulfilled_conditions_provider.dart' as _i82;
import '../providers/http_header_provider.dart' as _i18;
import '../providers/image_provider.dart' as _i11;
import '../providers/player_provider.dart' as _i24;
import '../providers/research_provider.dart' as _i57;
import '../providers/resource_provider.dart' as _i64;
import '../providers/resource_snapshot_provider.dart' as _i61;
import '../providers/selected_colonized_stellar_object_provider.dart' as _i20;
import '../providers/solar_systems_provider.dart' as _i53;
import '../providers/stored_resource_provider.dart' as _i69;
import '../providers/studied_researches_provider.dart' as _i84;
import '../providers/technologies_provider.dart' as _i79;
import '../providers/technology_upgrades_provider.dart' as _i50;
import '../services/event_service.dart' as _i14;
import '../services/hub_service.dart' as _i72;
import '../services/local_storage_service.dart' as _i75;
import '../services/navigation_wrapper.dart' as _i10;
import '../views/building_detail/building_detail_viewmodel.dart' as _i70;
import '../views/buildings/buildings_viewmodel.dart' as _i43;
import '../views/common/resource_viewmodel.dart' as _i58;
import '../views/common/technology_cost_viewmodel.dart' as _i66;
import '../views/galaxy/galaxy_viewmodel.dart' as _i52;
import '../views/home/home_viewmodel.dart' as _i4;
import '../views/home/widgets/construction_viewmodel.dart' as _i47;
import '../views/home/widgets/constructions_viewmodel.dart' as _i49;
import '../views/login/login_viewmodel.dart' as _i76;
import '../views/market/market_viewmodel.dart' as _i5;
import '../views/menus/colony_viewmodel.dart' as _i45;
import '../views/menus/menu_viewmodel.dart' as _i23;
import '../views/menus/player_colonies_viewmodel.dart' as _i26;
import '../views/perk_selection/perk_selection_viewmodel.dart' as _i54;
import '../views/register/register_viewmodel.dart' as _i6;
import '../views/research_detail/research_detail_viewmodel.dart' as _i7;
import '../views/researches/researches_viewmodel.dart' as _i56;
import '../views/resources/resources_viewmodel.dart' as _i63;
import '../views/resources/widgets/resource_viewmodel.dart' as _i62;
import '../views/solar_system/solar_system_viewmodel.dart' as _i13;
import '../views/species_selection/species_selection_viewmodel.dart' as _i36;
import '../views/splash/splash_viewmodel.dart' as _i77;
import '../views/start/start_viewmodel.dart' as _i65;
import '../views/tech_tree/tech_tree_viewmodel.dart' as _i78;
import '../views/technologies/technology_card_viewmodel.dart' as _i80;
import 'device_info.dart' as _i83;
import 'services_module.dart' as _i85; // ignore_for_file: unnecessary_lambdas

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
  gh.factory<_i30.ResourceRepository>(
      () => _i30.ResourceRepository(get<_i15.Dio>(), get<_i17.Logger>()));
  gh.factory<_i31.ResourceSnapshotRepository>(() =>
      _i31.ResourceSnapshotRepository(get<_i15.Dio>(), get<_i17.Logger>()));
  gh.factory<_i32.SetPlayersSpeciesExecuter>(() =>
      _i32.SetPlayersSpeciesExecuter(
          get<_i27.PlayerRepository>(),
          get<_i28.PlayerSpeciesRepository>(),
          get<_i24.PlayerProvider>(),
          get<_i33.DialogHelper>(),
          get<_i10.NavigationWrapper>()));
  gh.factory<_i34.SolarSystemRepository>(
      () => _i34.SolarSystemRepository(get<_i15.Dio>(), get<_i17.Logger>()));
  gh.factory<_i35.SpeciesRepository>(
      () => _i35.SpeciesRepository(get<_i15.Dio>(), get<_i17.Logger>()));
  gh.factory<_i36.SpeciesSelectionViewModel>(() =>
      _i36.SpeciesSelectionViewModel(get<_i10.NavigationWrapper>(),
          get<_i35.SpeciesRepository>(), get<_i11.AssetImageProvider>()));
  gh.factory<_i37.StellarObjectRepository>(() => _i37.StellarObjectRepository(
      get<_i15.Dio>(), get<_i17.Logger>(), get<_i22.ServerConnection>()));
  gh.factory<_i38.StoredResourceRepository>(
      () => _i38.StoredResourceRepository(get<_i15.Dio>(), get<_i17.Logger>()));
  gh.factory<_i39.TechnologyRepository>(
      () => _i39.TechnologyRepository(get<_i15.Dio>(), get<_i17.Logger>()));
  gh.factory<_i40.TechnologyUpgradeRepository>(() =>
      _i40.TechnologyUpgradeRepository(get<_i15.Dio>(), get<_i17.Logger>()));
  gh.factory<_i41.AuthorizationRepository>(
      () => _i41.AuthorizationRepository(get<_i15.Dio>(), get<_i17.Logger>()));
  gh.factory<_i42.BuildingRepository>(() => _i42.BuildingRepository(
      get<_i15.Dio>(),
      get<_i17.Logger>(),
      get<_i22.ServerConnection>(),
      get<_i18.HttpHeaderProvider>()));
  gh.factory<_i43.BuildingsViewModel>(
      () => _i43.BuildingsViewModel(get<_i44.BuildingsProvider>()));
  gh.factoryParam<_i45.ColonyViewModel, _i46.ColonizedStellarObject?, dynamic>(
      (colonizedStellarObject, _) => _i45.ColonyViewModel(
          get<_i20.SelectedColonizedStellarObjectProvider>(),
          get<_i37.StellarObjectRepository>(),
          get<_i11.AssetImageProvider>(),
          colonizedStellarObject));
  gh.factoryParam<_i47.ConstructionViewModel,
          _i48.StellarObjectDependentTechnologyUpgrade?, dynamic>(
      (_buildingConstruction, _) => _i47.ConstructionViewModel(
          get<_i37.StellarObjectRepository>(),
          get<_i20.SelectedColonizedStellarObjectProvider>(),
          get<_i11.AssetImageProvider>(),
          _buildingConstruction));
  gh.factory<_i49.ConstructionsViewModel>(() => _i49.ConstructionsViewModel(
      get<_i50.TechnologyUpgradesProvider>(), get<_i14.EventService>()));
  gh.factory<_i51.FetchSolarSystemExecuter>(() => _i51.FetchSolarSystemExecuter(
      get<_i33.DialogHelper>(), get<_i34.SolarSystemRepository>()));
  gh.factory<_i52.GalaxyViewModel>(
      () => _i52.GalaxyViewModel(get<_i53.SolarSystemsProvider>()));
  gh.factoryParam<_i54.PerkSelectionViewModel, _i55.AddPlayerSpeciesRequest?,
          dynamic>(
      (_playerSpecies, _) => _i54.PerkSelectionViewModel(
          get<_i25.PerkRepository>(),
          get<_i32.SetPlayersSpeciesExecuter>(),
          _playerSpecies));
  gh.factory<_i56.ResearchesViewModel>(
      () => _i56.ResearchesViewModel(get<_i57.ResearchProvider>()));
  gh.factoryParam<_i58.ResourceViewModel, _i59.Resource?, _i60.TechnologyCost?>(
      (_resource, _technologyCost) => _i58.ResourceViewModel(
          get<_i14.EventService>(),
          get<_i61.ResourceSnapshotProvider>(),
          _resource,
          _technologyCost));
  gh.factoryParam<_i62.ResourceViewModel, _i59.Resource?, dynamic>(
      (resource, _) => _i62.ResourceViewModel(get<_i14.EventService>(),
          get<_i61.ResourceSnapshotProvider>(), resource));
  gh.factory<_i63.ResourcesViewModel>(
      () => _i63.ResourcesViewModel(get<_i64.ResourceProvider>()));
  gh.factory<_i65.StartViewModel>(() => _i65.StartViewModel(
      get<_i51.FetchSolarSystemExecuter>(), get<_i14.EventService>()));
  gh.factoryParam<_i66.TechnologyCostViewModel, _i67.Technology?,
          _i9.FinishedTechnology?>(
      (technology, finishedTechnology) => _i66.TechnologyCostViewModel(
          get<_i39.TechnologyRepository>(),
          get<_i64.ResourceProvider>(),
          technology,
          finishedTechnology));
  gh.factory<_i68.UpgradeTechnologyExecuter>(() =>
      _i68.UpgradeTechnologyExecuter(
          get<_i14.EventService>(),
          get<_i33.DialogHelper>(),
          get<_i39.TechnologyRepository>(),
          get<_i50.TechnologyUpgradesProvider>(),
          get<_i69.StoredResourceProvider>()));
  gh.factoryParam<_i70.BuildingDetailViewModel, _i71.Building?,
          _i9.FinishedTechnology?>(
      (building, finishedTechnology) => _i70.BuildingDetailViewModel(
          get<_i39.TechnologyRepository>(),
          get<_i64.ResourceProvider>(),
          get<_i11.AssetImageProvider>(),
          building,
          finishedTechnology));
  gh.factory<_i72.HubService>(() => _i72.HubService(get<_i73.TechnologyHub>()));
  gh.factory<_i74.LoginExecuter>(() => _i74.LoginExecuter(
      get<_i41.AuthorizationRepository>(),
      get<_i27.PlayerRepository>(),
      get<_i19.AuthorizationTokenProvider>(),
      get<_i24.PlayerProvider>(),
      get<_i33.DialogHelper>(),
      get<_i10.NavigationWrapper>(),
      get<_i72.HubService>(),
      get<_i75.LocalStorageService>()));
  gh.factoryParam<_i76.LoginViewModel, String?, dynamic>((lastEmail, _) =>
      _i76.LoginViewModel(
          get<_i74.LoginExecuter>(), get<_i10.NavigationWrapper>(), lastEmail));
  gh.factory<_i77.SplashViewModel>(() => _i77.SplashViewModel(
      get<_i72.HubService>(),
      get<_i75.LocalStorageService>(),
      get<_i10.NavigationWrapper>(),
      get<_i24.PlayerProvider>(),
      get<_i27.PlayerRepository>(),
      get<_i19.AuthorizationTokenProvider>()));
  gh.factoryParam<_i78.TechTreeViewModel, _i67.Technology?, dynamic>(
      (_technology, _) => _i78.TechTreeViewModel(
          get<_i79.TechnologiesProvider>(), _technology));
  gh.factoryParam<_i80.TechnologyCardViewModel, _i67.Technology?, dynamic>(
      (technology, _) => _i80.TechnologyCardViewModel(
          get<_i10.NavigationWrapper>(),
          get<_i50.TechnologyUpgradesProvider>(),
          get<_i81.FinishedTechnologiesProvider>(),
          get<_i11.AssetImageProvider>(),
          get<_i69.StoredResourceProvider>(),
          get<_i82.FulfilledConditionsProvider>(),
          get<_i20.SelectedColonizedStellarObjectProvider>(),
          get<_i68.UpgradeTechnologyExecuter>(),
          get<_i14.EventService>(),
          get<_i12.ResourceHelper>(),
          technology));
  gh.singleton<_i11.AssetImageProvider>(_i11.AssetImageProvider());
  gh.singleton<_i19.AuthorizationTokenProvider>(
      _i19.AuthorizationTokenProvider());
  gh.singletonAsync<_i83.DeviceInfo>(() => _i83.DeviceInfo.instance());
  gh.singleton<_i14.EventService>(_i14.EventService());
  gh.singleton<_i75.LocalStorageService>(_i75.LocalStorageService());
  gh.singleton<_i17.Logger>(servicesModule.logger);
  gh.singleton<_i10.NavigationWrapper>(_i10.NavigationWrapper());
  gh.singleton<_i24.PlayerProvider>(_i24.PlayerProvider());
  gh.singleton<_i20.SelectedColonizedStellarObjectProvider>(
      _i20.SelectedColonizedStellarObjectProvider(get<_i24.PlayerProvider>()));
  gh.singleton<_i22.ServerConnection>(_i22.ServerConnection());
  gh.singleton<_i33.DialogHelper>(
      _i33.DialogHelper(get<_i10.NavigationWrapper>()));
  gh.singleton<_i53.SolarSystemsProvider>(
      _i53.SolarSystemsProvider(get<_i34.SolarSystemRepository>()));
  gh.singleton<_i84.StudiedResearchesProvider>(
      _i84.StudiedResearchesProvider(get<_i16.FinishedTechnologyRepository>()));
  gh.singleton<_i50.TechnologyUpgradesProvider>(
      _i50.TechnologyUpgradesProvider(get<_i40.TechnologyUpgradeRepository>()));
  gh.singleton<_i44.BuildingsProvider>(
      _i44.BuildingsProvider(get<_i42.BuildingRepository>()));
  gh.singleton<_i81.FinishedTechnologiesProvider>(
      _i81.FinishedTechnologiesProvider(
          get<_i16.FinishedTechnologyRepository>()));
  gh.singleton<_i82.FulfilledConditionsProvider>(
      _i82.FulfilledConditionsProvider(get<_i39.TechnologyRepository>()));
  gh.singleton<_i57.ResearchProvider>(
      _i57.ResearchProvider(get<_i29.ResearchRepository>()));
  gh.singleton<_i64.ResourceProvider>(
      _i64.ResourceProvider(get<_i30.ResourceRepository>()));
  gh.singleton<_i61.ResourceSnapshotProvider>(_i61.ResourceSnapshotProvider(
      get<_i31.ResourceSnapshotRepository>(),
      get<_i20.SelectedColonizedStellarObjectProvider>()));
  gh.singleton<_i69.StoredResourceProvider>(_i69.StoredResourceProvider(
      get<_i14.EventService>(),
      get<_i61.ResourceSnapshotProvider>(),
      get<_i20.SelectedColonizedStellarObjectProvider>()));
  gh.singleton<_i79.TechnologiesProvider>(
      _i79.TechnologiesProvider(get<_i39.TechnologyRepository>()));
  gh.singleton<_i73.TechnologyHub>(_i73.TechnologyHub(
      get<_i14.EventService>(),
      get<_i81.FinishedTechnologiesProvider>(),
      get<_i69.StoredResourceProvider>(),
      get<_i50.TechnologyUpgradesProvider>(),
      get<_i82.FulfilledConditionsProvider>(),
      get<_i22.ServerConnection>(),
      get<_i18.HttpHeaderProvider>()));
  return get;
}

class _$ServicesModule extends _i85.ServicesModule {}
