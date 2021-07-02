// GENERATED CODE - DO NOT MODIFY BY HAND

// **************************************************************************
// InjectableConfigGenerator
// **************************************************************************

import 'package:dio/dio.dart' as _i11;
import 'package:get_it/get_it.dart' as _i1;
import 'package:injectable/injectable.dart' as _i2;
import 'package:logger/logger.dart' as _i16;

import '../communications/dtos/add_player_species_request.dart' as _i51;
import '../communications/hubs/building_hub.dart' as _i70;
import '../communications/interceptors/header_interceptor.dart' as _i3;
import '../communications/repositories/authorization_repository.dart' as _i36;
import '../communications/repositories/building_chain_repository.dart' as _i37;
import '../communications/repositories/building_repository.dart' as _i38;
import '../communications/repositories/built_building_repository.dart' as _i41;
import '../communications/repositories/image_respository.dart' as _i15;
import '../communications/repositories/perk_repository.dart' as _i18;
import '../communications/repositories/player_repository.dart' as _i21;
import '../communications/repositories/player_species_repository.dart' as _i22;
import '../communications/repositories/research_repository.dart' as _i23;
import '../communications/repositories/research_study_repository.dart' as _i24;
import '../communications/repositories/resource_repository.dart' as _i25;
import '../communications/repositories/resource_snapshot_repository.dart'
    as _i26;
import '../communications/repositories/solar_system_repository.dart' as _i29;
import '../communications/repositories/species_repository.dart' as _i30;
import '../communications/repositories/stellar_object_repository.dart' as _i33;
import '../communications/repositories/stored_resource_repository.dart' as _i34;
import '../communications/repositories/studied_research_repository.dart'
    as _i35;
import '../communications/server_connection.dart' as _i17;
import '../executers/build_building_executer.dart' as _i83;
import '../executers/fetch_solar_system_executer.dart' as _i46;
import '../executers/login_executer.dart' as _i71;
import '../executers/set_players_species_executer.dart' as _i27;
import '../helpers/dialog_helper.dart' as _i28;
import '../helpers/resource_helper.dart' as _i7;
import '../models/buildings/building.dart' as _i65;
import '../models/buildings/building_construction.dart' as _i45;
import '../models/buildings/building_cost.dart' as _i59;
import '../models/buildings/built_building.dart' as _i66;
import '../models/players/colonized_stellar_object.dart' as _i43;
import '../models/researches/research.dart' as _i75;
import '../models/researches/research_cost.dart' as _i56;
import '../models/researches/studied_research.dart' as _i76;
import '../models/resources/resource.dart' as _i55;
import '../providers/authorization_token_provider.dart' as _i13;
import '../providers/building_chain_provider.dart' as _i68;
import '../providers/buildings_provider.dart' as _i40;
import '../providers/constructed_buildings_provider.dart' as _i85;
import '../providers/http_header_provider.dart' as _i12;
import '../providers/image_provider.dart' as _i32;
import '../providers/player_provider.dart' as _i20;
import '../providers/research_provider.dart' as _i53;
import '../providers/research_study_provider.dart' as _i80;
import '../providers/resource_provider.dart' as _i62;
import '../providers/resource_snapshot_provider.dart' as _i57;
import '../providers/selected_colonized_stellar_object_provider.dart' as _i14;
import '../providers/solar_systems_provider.dart' as _i48;
import '../providers/stored_resource_provider.dart' as _i79;
import '../providers/studied_researches_provider.dart' as _i78;
import '../services/event_service.dart' as _i9;
import '../services/hub_service.dart' as _i69;
import '../services/local_storage_service.dart' as _i72;
import '../services/navigation_wrapper.dart' as _i10;
import '../views/building_detail/building_detail_viewmodel.dart' as _i64;
import '../views/building_detail/widgets/resource_viewmodel.dart' as _i58;
import '../views/buildings/buildings_viewmodel.dart' as _i39;
import '../views/buildings/widgets/building_viewmodel.dart' as _i84;
import '../views/galaxy/galaxy_viewmodel.dart' as _i47;
import '../views/home/home_viewmodel.dart' as _i4;
import '../views/home/widgets/construction_viewmodel.dart' as _i44;
import '../views/home/widgets/constructions_viewmodel.dart' as _i67;
import '../views/login/login_viewmodel.dart' as _i73;
import '../views/market/market_viewmodel.dart' as _i5;
import '../views/menus/colony_viewmodel.dart' as _i42;
import '../views/menus/menu_viewmodel.dart' as _i49;
import '../views/menus/player_colonies_viewmodel.dart' as _i19;
import '../views/menus/resource_viewmodel.dart' as _i81;
import '../views/perk_selection/perk_selection_viewmodel.dart' as _i50;
import '../views/register/register_viewmodel.dart' as _i6;
import '../views/research_detail/research_detail_viewmodel.dart' as _i74;
import '../views/research_detail/widgets/resource_viewmodel.dart' as _i54;
import '../views/researches/researches_viewmodel.dart' as _i52;
import '../views/researches/widgets/research_viewmodel.dart' as _i77;
import '../views/resources/resources_viewmodel.dart' as _i61;
import '../views/resources/widgets/resource_viewmodel.dart' as _i60;
import '../views/solar_system/solar_system_viewmodel.dart' as _i8;
import '../views/species_selection/species_selection_viewmodel.dart' as _i31;
import '../views/splash/splash_viewmodel.dart' as _i82;
import '../views/start/start_viewmodel.dart' as _i63;
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
  gh.factory<_i11.Dio>(() => servicesModule.dio(get<_i3.HeaderInterceptor>()));
  gh.factory<_i12.HttpHeaderProvider>(() => _i12.HttpHeaderProvider(
      get<_i13.AuthorizationTokenProvider>(),
      get<_i14.SelectedColonizedStellarObjectProvider>()));
  gh.factory<_i15.ImageRepository>(() => _i15.ImageRepository(
      get<_i11.Dio>(),
      get<_i16.Logger>(),
      get<_i17.ServerConnection>(),
      get<_i12.HttpHeaderProvider>()));
  gh.factory<_i18.PerkRepository>(
      () => _i18.PerkRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i19.PlayerColoniesViewModel>(
      () => _i19.PlayerColoniesViewModel(get<_i20.PlayerProvider>()));
  gh.factory<_i21.PlayerRepository>(
      () => _i21.PlayerRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i22.PlayerSpeciesRepository>(
      () => _i22.PlayerSpeciesRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i23.ResearchRepository>(() => _i23.ResearchRepository(
      get<_i11.Dio>(),
      get<_i16.Logger>(),
      get<_i17.ServerConnection>(),
      get<_i12.HttpHeaderProvider>()));
  gh.factory<_i24.ResearchStudyRepository>(
      () => _i24.ResearchStudyRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i25.ResourceRepository>(
      () => _i25.ResourceRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i26.ResourceSnapshotRepository>(() =>
      _i26.ResourceSnapshotRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i27.SetPlayersSpeciesExecuter>(() =>
      _i27.SetPlayersSpeciesExecuter(
          get<_i21.PlayerRepository>(),
          get<_i22.PlayerSpeciesRepository>(),
          get<_i20.PlayerProvider>(),
          get<_i28.DialogHelper>(),
          get<_i10.NavigationWrapper>()));
  gh.factory<_i29.SolarSystemRepository>(
      () => _i29.SolarSystemRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i30.SpeciesRepository>(
      () => _i30.SpeciesRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i31.SpeciesSelectionViewModel>(() =>
      _i31.SpeciesSelectionViewModel(get<_i10.NavigationWrapper>(),
          get<_i30.SpeciesRepository>(), get<_i32.SpeciesImageProvider>()));
  gh.factory<_i33.StellarObjectRepository>(() => _i33.StellarObjectRepository(
      get<_i11.Dio>(), get<_i16.Logger>(), get<_i17.ServerConnection>()));
  gh.factory<_i34.StoredResourceRepository>(
      () => _i34.StoredResourceRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i35.StudiedResearchRepository>(() =>
      _i35.StudiedResearchRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i36.AuthorizationRepository>(
      () => _i36.AuthorizationRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i37.BuildingChainRepository>(
      () => _i37.BuildingChainRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i38.BuildingRepository>(() => _i38.BuildingRepository(
      get<_i11.Dio>(),
      get<_i16.Logger>(),
      get<_i17.ServerConnection>(),
      get<_i12.HttpHeaderProvider>()));
  gh.factory<_i39.BuildingsViewModel>(
      () => _i39.BuildingsViewModel(get<_i40.BuildingsProvider>()));
  gh.factory<_i41.BuiltBuildingRepository>(
      () => _i41.BuiltBuildingRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factoryParam<_i42.ColonyViewModel, _i43.ColonizedStellarObject, dynamic>(
      (colonizedStellarObject, _) => _i42.ColonyViewModel(
          get<_i14.SelectedColonizedStellarObjectProvider>(),
          get<_i33.StellarObjectRepository>(),
          colonizedStellarObject));
  gh.factoryParam<_i44.ConstructionViewModel, _i45.BuildingConstruction,
          dynamic>(
      (_buildingConstruction, _) => _i44.ConstructionViewModel(
          get<_i33.StellarObjectRepository>(),
          get<_i14.SelectedColonizedStellarObjectProvider>(),
          _buildingConstruction));
  gh.factory<_i46.FetchSolarSystemExecuter>(() => _i46.FetchSolarSystemExecuter(
      get<_i28.DialogHelper>(), get<_i29.SolarSystemRepository>()));
  gh.factory<_i47.GalaxyViewModel>(
      () => _i47.GalaxyViewModel(get<_i48.SolarSystemsProvider>()));
  gh.factory<_i49.MenuViewModel>(() => _i49.MenuViewModel(
      get<_i10.NavigationWrapper>(),
      get<_i20.PlayerProvider>(),
      get<_i32.SpeciesImageProvider>()));
  gh.factoryParam<_i50.PerkSelectionViewModel, _i51.AddPlayerSpeciesRequest,
          dynamic>(
      (_playerSpecies, _) => _i50.PerkSelectionViewModel(
          get<_i18.PerkRepository>(),
          get<_i27.SetPlayersSpeciesExecuter>(),
          _playerSpecies));
  gh.factory<_i52.ResearchesViewModel>(
      () => _i52.ResearchesViewModel(get<_i53.ResearchProvider>()));
  gh.factoryParam<_i54.ResourceViewModel, _i55.Resource, _i56.ResearchCost>(
      (_resource, _researchCost) => _i54.ResourceViewModel(
          get<_i9.EventService>(),
          get<_i57.ResourceSnapshotProvider>(),
          get<_i14.SelectedColonizedStellarObjectProvider>(),
          _resource,
          _researchCost));
  gh.factoryParam<_i58.ResourceViewModel, _i55.Resource, _i59.BuildingCost>(
      (_resource, _buildingCost) => _i58.ResourceViewModel(
          get<_i9.EventService>(),
          get<_i57.ResourceSnapshotProvider>(),
          get<_i14.SelectedColonizedStellarObjectProvider>(),
          _resource,
          _buildingCost));
  gh.factoryParam<_i60.ResourceViewModel, _i55.Resource, dynamic>(
      (_resource, _) => _i60.ResourceViewModel(
          get<_i9.EventService>(),
          get<_i57.ResourceSnapshotProvider>(),
          get<_i14.SelectedColonizedStellarObjectProvider>(),
          _resource));
  gh.factory<_i61.ResourcesViewModel>(
      () => _i61.ResourcesViewModel(get<_i62.ResourceProvider>()));
  gh.factory<_i63.StartViewModel>(() => _i63.StartViewModel(
      get<_i46.FetchSolarSystemExecuter>(), get<_i9.EventService>()));
  gh.factoryParam<_i64.BuildingDetailViewModel, _i65.Building,
          _i66.BuiltBuilding>(
      (building, builtBuilding) => _i64.BuildingDetailViewModel(
          get<_i38.BuildingRepository>(),
          get<_i62.ResourceProvider>(),
          get<_i32.BuildingImageProvider>(),
          building,
          builtBuilding));
  gh.factory<_i67.ConstructionsViewModel>(() => _i67.ConstructionsViewModel(
      get<_i68.BuildingChainProvider>(), get<_i9.EventService>()));
  gh.factory<_i69.HubService>(() => _i69.HubService(get<_i70.BuildingHub>()));
  gh.factory<_i71.LoginExecuter>(() => _i71.LoginExecuter(
      get<_i36.AuthorizationRepository>(),
      get<_i21.PlayerRepository>(),
      get<_i13.AuthorizationTokenProvider>(),
      get<_i20.PlayerProvider>(),
      get<_i28.DialogHelper>(),
      get<_i10.NavigationWrapper>(),
      get<_i69.HubService>(),
      get<_i72.LocalStorageService>()));
  gh.factoryParam<_i73.LoginViewModel, String, dynamic>((lastEmail, _) =>
      _i73.LoginViewModel(
          get<_i71.LoginExecuter>(), get<_i10.NavigationWrapper>(), lastEmail));
  gh.factoryParam<_i74.ResearchDetailViewModel, _i75.Research,
          _i76.StudiedResearch>(
      (research, studiedResearch) => _i74.ResearchDetailViewModel(
          get<_i23.ResearchRepository>(),
          get<_i62.ResourceProvider>(),
          get<_i32.ResearchImageProvider>(),
          research,
          studiedResearch));
  gh.factoryParam<_i77.ResearchViewModel, _i75.Research, dynamic>(
      (_research, _) => _i77.ResearchViewModel(
          get<_i10.NavigationWrapper>(),
          get<_i78.StudiedResearchesProvider>(),
          get<_i32.ResearchImageProvider>(),
          get<_i79.StoredResourceProvider>(),
          get<_i80.ResearchStudyProvider>(),
          get<_i9.EventService>(),
          get<_i7.ResourceHelper>(),
          _research));
  gh.factory<_i81.ResourceViewModel>(() => _i81.ResourceViewModel(
      get<_i9.EventService>(),
      get<_i62.ResourceProvider>(),
      get<_i79.StoredResourceProvider>()));
  gh.factory<_i82.SplashViewModel>(() => _i82.SplashViewModel(
      get<_i69.HubService>(),
      get<_i72.LocalStorageService>(),
      get<_i10.NavigationWrapper>(),
      get<_i20.PlayerProvider>(),
      get<_i21.PlayerRepository>(),
      get<_i13.AuthorizationTokenProvider>()));
  gh.factory<_i83.BuildBuildingExecuter>(() => _i83.BuildBuildingExecuter(
      get<_i9.EventService>(),
      get<_i28.DialogHelper>(),
      get<_i38.BuildingRepository>(),
      get<_i68.BuildingChainProvider>(),
      get<_i79.StoredResourceProvider>()));
  gh.factoryParam<_i84.BuildingViewModel, _i65.Building, dynamic>(
      (_building, _) => _i84.BuildingViewModel(
          get<_i10.NavigationWrapper>(),
          get<_i68.BuildingChainProvider>(),
          get<_i85.ConstructedBuildingsProvider>(),
          get<_i14.SelectedColonizedStellarObjectProvider>(),
          get<_i32.BuildingImageProvider>(),
          get<_i79.StoredResourceProvider>(),
          get<_i83.BuildBuildingExecuter>(),
          get<_i9.EventService>(),
          get<_i7.ResourceHelper>(),
          _building));
  gh.singleton<_i13.AuthorizationTokenProvider>(
      _i13.AuthorizationTokenProvider());
  gh.singletonAsync<_i86.DeviceInfo>(() => _i86.DeviceInfo.instance());
  gh.singleton<_i9.EventService>(_i9.EventService());
  gh.singleton<_i72.LocalStorageService>(_i72.LocalStorageService());
  gh.singleton<_i16.Logger>(servicesModule.logger);
  gh.singleton<_i10.NavigationWrapper>(_i10.NavigationWrapper());
  gh.singleton<_i20.PlayerProvider>(_i20.PlayerProvider());
  gh.singleton<_i14.SelectedColonizedStellarObjectProvider>(
      _i14.SelectedColonizedStellarObjectProvider(get<_i20.PlayerProvider>()));
  gh.singleton<_i17.ServerConnection>(_i17.ServerConnection());
  gh.singleton<_i28.DialogHelper>(
      _i28.DialogHelper(get<_i10.NavigationWrapper>()));
  gh.singleton<_i32.ResearchImageProvider>(
      _i32.ResearchImageProvider(get<_i15.ImageRepository>()));
  gh.singleton<_i48.SolarSystemsProvider>(
      _i48.SolarSystemsProvider(get<_i29.SolarSystemRepository>()));
  gh.singleton<_i32.SpeciesImageProvider>(
      _i32.SpeciesImageProvider(get<_i15.ImageRepository>()));
  gh.singleton<_i32.StellarObjectImageProvider>(
      _i32.StellarObjectImageProvider(get<_i15.ImageRepository>()));
  gh.singleton<_i78.StudiedResearchesProvider>(
      _i78.StudiedResearchesProvider(get<_i35.StudiedResearchRepository>()));
  gh.singleton<_i32.BuildingImageProvider>(
      _i32.BuildingImageProvider(get<_i15.ImageRepository>()));
  gh.singleton<_i40.BuildingsProvider>(
      _i40.BuildingsProvider(get<_i38.BuildingRepository>()));
  gh.singleton<_i85.ConstructedBuildingsProvider>(
      _i85.ConstructedBuildingsProvider(get<_i41.BuiltBuildingRepository>()));
  gh.singleton<_i53.ResearchProvider>(
      _i53.ResearchProvider(get<_i23.ResearchRepository>()));
  gh.singleton<_i80.ResearchStudyProvider>(
      _i80.ResearchStudyProvider(get<_i24.ResearchStudyRepository>()));
  gh.singleton<_i62.ResourceProvider>(
      _i62.ResourceProvider(get<_i25.ResourceRepository>()));
  gh.singleton<_i57.ResourceSnapshotProvider>(
      _i57.ResourceSnapshotProvider(get<_i26.ResourceSnapshotRepository>()));
  gh.singleton<_i79.StoredResourceProvider>(_i79.StoredResourceProvider(
      get<_i9.EventService>(),
      get<_i57.ResourceSnapshotProvider>(),
      get<_i14.SelectedColonizedStellarObjectProvider>()));
  gh.singleton<_i68.BuildingChainProvider>(
      _i68.BuildingChainProvider(get<_i37.BuildingChainRepository>()));
  gh.singleton<_i70.BuildingHub>(_i70.BuildingHub(
      get<_i9.EventService>(),
      get<_i17.ServerConnection>(),
      get<_i12.HttpHeaderProvider>(),
      get<_i68.BuildingChainProvider>(),
      get<_i85.ConstructedBuildingsProvider>()));
  return get;
}

class _$ServicesModule extends _i87.ServicesModule {}
