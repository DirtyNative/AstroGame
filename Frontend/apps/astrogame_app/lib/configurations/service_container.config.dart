// GENERATED CODE - DO NOT MODIFY BY HAND

// **************************************************************************
// InjectableConfigGenerator
// **************************************************************************

import 'package:dio/dio.dart' as _i11;
import 'package:get_it/get_it.dart' as _i1;
import 'package:injectable/injectable.dart' as _i2;
import 'package:logger/logger.dart' as _i16;

import '../communications/dtos/add_player_species_request.dart' as _i47;
import '../communications/hubs/building_hub.dart' as _i61;
import '../communications/interceptors/header_interceptor.dart' as _i3;
import '../communications/repositories/authorization_repository.dart' as _i34;
import '../communications/repositories/building_chain_repository.dart' as _i35;
import '../communications/repositories/building_repository.dart' as _i36;
import '../communications/repositories/built_building_repository.dart' as _i39;
import '../communications/repositories/perk_repository.dart' as _i15;
import '../communications/repositories/player_repository.dart' as _i19;
import '../communications/repositories/player_species_repository.dart' as _i20;
import '../communications/repositories/research_repository.dart' as _i21;
import '../communications/repositories/research_study_repository.dart' as _i23;
import '../communications/repositories/resource_repository.dart' as _i24;
import '../communications/repositories/resource_snapshot_repository.dart'
    as _i25;
import '../communications/repositories/solar_system_repository.dart' as _i28;
import '../communications/repositories/species_repository.dart' as _i29;
import '../communications/repositories/stellar_object_repository.dart' as _i31;
import '../communications/repositories/stored_resource_repository.dart' as _i32;
import '../communications/repositories/studied_research_repository.dart'
    as _i33;
import '../communications/server_connection.dart' as _i22;
import '../executers/build_building_executer.dart' as _i71;
import '../executers/fetch_solar_system_executer.dart' as _i44;
import '../executers/login_executer.dart' as _i62;
import '../executers/set_players_species_executer.dart' as _i26;
import '../helpers/dialog_helper.dart' as _i27;
import '../helpers/resource_helper.dart' as _i7;
import '../models/buildings/building.dart' as _i73;
import '../models/buildings/building_construction.dart' as _i43;
import '../models/buildings/building_cost.dart' as _i54;
import '../models/buildings/built_building.dart' as _i74;
import '../models/players/colonized_stellar_object.dart' as _i41;
import '../models/researches/research.dart' as _i65;
import '../models/resources/resource.dart' as _i51;
import '../providers/authorization_token_provider.dart' as _i13;
import '../providers/building_chain_provider.dart' as _i59;
import '../providers/building_image_provider.dart' as _i75;
import '../providers/buildings_provider.dart' as _i38;
import '../providers/constructed_buildings_provider.dart' as _i77;
import '../providers/http_header_provider.dart' as _i12;
import '../providers/player_provider.dart' as _i18;
import '../providers/research_image_provider.dart' as _i67;
import '../providers/research_provider.dart' as _i49;
import '../providers/research_study_provider.dart' as _i69;
import '../providers/resource_provider.dart' as _i56;
import '../providers/resource_snapshot_provider.dart' as _i52;
import '../providers/selected_colonized_stellar_object_provider.dart' as _i14;
import '../providers/stored_resource_provider.dart' as _i68;
import '../providers/studied_researches_provider.dart' as _i66;
import '../services/event_service.dart' as _i9;
import '../services/hub_service.dart' as _i60;
import '../services/navigation_wrapper.dart' as _i10;
import '../views/building_detail/building_detail_viewmodel.dart' as _i72;
import '../views/building_detail/widgets/resource_viewmodel.dart' as _i53;
import '../views/buildings/buildings_viewmodel.dart' as _i37;
import '../views/buildings/widgets/building_viewmodel.dart' as _i76;
import '../views/home/home_viewmodel.dart' as _i4;
import '../views/home/widgets/construction_viewmodel.dart' as _i42;
import '../views/home/widgets/constructions_viewmodel.dart' as _i58;
import '../views/login/login_viewmodel.dart' as _i63;
import '../views/market/market_viewmodel.dart' as _i5;
import '../views/menus/colony_viewmodel.dart' as _i40;
import '../views/menus/menu_viewmodel.dart' as _i45;
import '../views/menus/player_colonies_viewmodel.dart' as _i17;
import '../views/menus/resource_viewmodel.dart' as _i70;
import '../views/perk_selection/perk_selection_viewmodel.dart' as _i46;
import '../views/register/register_viewmodel.dart' as _i6;
import '../views/researches/researches_viewmodel.dart' as _i48;
import '../views/researches/widgets/research_viewmodel.dart' as _i64;
import '../views/resources/resources_viewmodel.dart' as _i55;
import '../views/resources/widgets/resource_viewmodel.dart' as _i50;
import '../views/solar_system/solar_system_viewmodel.dart' as _i8;
import '../views/species_selection/species_selection_viewmodel.dart' as _i30;
import '../views/start/start_viewmodel.dart' as _i57;
import 'device_info.dart' as _i78;
import 'services_module.dart' as _i79; // ignore_for_file: unnecessary_lambdas

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
  gh.factory<_i21.ResearchRepository>(() => _i21.ResearchRepository(
      get<_i11.Dio>(),
      get<_i16.Logger>(),
      get<_i22.ServerConnection>(),
      get<_i12.HttpHeaderProvider>()));
  gh.factory<_i23.ResearchStudyRepository>(
      () => _i23.ResearchStudyRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i24.ResourceRepository>(
      () => _i24.ResourceRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i25.ResourceSnapshotRepository>(() =>
      _i25.ResourceSnapshotRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i26.SetPlayersSpeciesExecuter>(() =>
      _i26.SetPlayersSpeciesExecuter(
          get<_i19.PlayerRepository>(),
          get<_i20.PlayerSpeciesRepository>(),
          get<_i18.PlayerProvider>(),
          get<_i27.DialogHelper>(),
          get<_i10.NavigationWrapper>()));
  gh.factory<_i28.SolarSystemRepository>(
      () => _i28.SolarSystemRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i29.SpeciesRepository>(() => _i29.SpeciesRepository(
      get<_i11.Dio>(), get<_i16.Logger>(), get<_i22.ServerConnection>()));
  gh.factory<_i30.SpeciesSelectionViewModel>(() =>
      _i30.SpeciesSelectionViewModel(
          get<_i10.NavigationWrapper>(), get<_i29.SpeciesRepository>()));
  gh.factory<_i31.StellarObjectRepository>(() => _i31.StellarObjectRepository(
      get<_i11.Dio>(), get<_i16.Logger>(), get<_i22.ServerConnection>()));
  gh.factory<_i32.StoredResourceRepository>(
      () => _i32.StoredResourceRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i33.StudiedResearchRepository>(() =>
      _i33.StudiedResearchRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i34.AuthorizationRepository>(
      () => _i34.AuthorizationRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i35.BuildingChainRepository>(
      () => _i35.BuildingChainRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factory<_i36.BuildingRepository>(() => _i36.BuildingRepository(
      get<_i11.Dio>(),
      get<_i16.Logger>(),
      get<_i22.ServerConnection>(),
      get<_i12.HttpHeaderProvider>()));
  gh.factory<_i37.BuildingsViewModel>(
      () => _i37.BuildingsViewModel(get<_i38.BuildingsProvider>()));
  gh.factory<_i39.BuiltBuildingRepository>(
      () => _i39.BuiltBuildingRepository(get<_i11.Dio>(), get<_i16.Logger>()));
  gh.factoryParam<_i40.ColonyViewModel, _i41.ColonizedStellarObject, dynamic>(
      (colonizedStellarObject, _) => _i40.ColonyViewModel(
          get<_i14.SelectedColonizedStellarObjectProvider>(),
          get<_i31.StellarObjectRepository>(),
          colonizedStellarObject));
  gh.factoryParam<_i42.ConstructionViewModel, _i43.BuildingConstruction,
          dynamic>(
      (_buildingConstruction, _) => _i42.ConstructionViewModel(
          get<_i31.StellarObjectRepository>(),
          get<_i14.SelectedColonizedStellarObjectProvider>(),
          _buildingConstruction));
  gh.factory<_i44.FetchSolarSystemExecuter>(() => _i44.FetchSolarSystemExecuter(
      get<_i27.DialogHelper>(), get<_i28.SolarSystemRepository>()));
  gh.factory<_i45.MenuViewModel>(() => _i45.MenuViewModel(
      get<_i10.NavigationWrapper>(),
      get<_i29.SpeciesRepository>(),
      get<_i18.PlayerProvider>()));
  gh.factoryParam<_i46.PerkSelectionViewModel, _i47.AddPlayerSpeciesRequest,
          dynamic>(
      (_playerSpecies, _) => _i46.PerkSelectionViewModel(
          get<_i15.PerkRepository>(),
          get<_i26.SetPlayersSpeciesExecuter>(),
          _playerSpecies));
  gh.factory<_i48.ResearchesViewModel>(
      () => _i48.ResearchesViewModel(get<_i49.ResearchProvider>()));
  gh.factoryParam<_i50.ResourceViewModel, _i51.Resource, dynamic>(
      (_resource, _) => _i50.ResourceViewModel(
          get<_i9.EventService>(),
          get<_i52.ResourceSnapshotProvider>(),
          get<_i14.SelectedColonizedStellarObjectProvider>(),
          _resource));
  gh.factoryParam<_i53.ResourceViewModel, _i51.Resource, _i54.BuildingCost>(
      (_resource, _buildingCost) => _i53.ResourceViewModel(
          get<_i9.EventService>(),
          get<_i52.ResourceSnapshotProvider>(),
          get<_i14.SelectedColonizedStellarObjectProvider>(),
          _resource,
          _buildingCost));
  gh.factory<_i55.ResourcesViewModel>(
      () => _i55.ResourcesViewModel(get<_i56.ResourceProvider>()));
  gh.factory<_i57.StartViewModel>(() => _i57.StartViewModel(
      get<_i44.FetchSolarSystemExecuter>(), get<_i9.EventService>()));
  gh.factory<_i58.ConstructionsViewModel>(() => _i58.ConstructionsViewModel(
      get<_i59.BuildingChainProvider>(), get<_i9.EventService>()));
  gh.factory<_i60.HubService>(() => _i60.HubService(get<_i61.BuildingHub>()));
  gh.factory<_i62.LoginExecuter>(() => _i62.LoginExecuter(
      get<_i34.AuthorizationRepository>(),
      get<_i19.PlayerRepository>(),
      get<_i13.AuthorizationTokenProvider>(),
      get<_i18.PlayerProvider>(),
      get<_i27.DialogHelper>(),
      get<_i10.NavigationWrapper>(),
      get<_i60.HubService>()));
  gh.factory<_i63.LoginViewModel>(() => _i63.LoginViewModel(
      get<_i62.LoginExecuter>(), get<_i10.NavigationWrapper>()));
  gh.factoryParam<_i64.ResearchViewModel, _i65.Research, dynamic>(
      (_research, _) => _i64.ResearchViewModel(
          get<_i10.NavigationWrapper>(),
          get<_i66.StudiedResearchesProvider>(),
          get<_i67.ResearchImageProvider>(),
          get<_i68.StoredResourceProvider>(),
          get<_i69.ResearchStudyProvider>(),
          get<_i9.EventService>(),
          get<_i7.ResourceHelper>(),
          _research));
  gh.factory<_i70.ResourceViewModel>(() => _i70.ResourceViewModel(
      get<_i9.EventService>(),
      get<_i56.ResourceProvider>(),
      get<_i68.StoredResourceProvider>()));
  gh.factory<_i71.BuildBuildingExecuter>(() => _i71.BuildBuildingExecuter(
      get<_i9.EventService>(),
      get<_i27.DialogHelper>(),
      get<_i36.BuildingRepository>(),
      get<_i59.BuildingChainProvider>(),
      get<_i68.StoredResourceProvider>()));
  gh.factoryParam<_i72.BuildingDetailViewModel, _i73.Building,
          _i74.BuiltBuilding>(
      (building, builtBuilding) => _i72.BuildingDetailViewModel(
          get<_i36.BuildingRepository>(),
          get<_i56.ResourceProvider>(),
          get<_i75.BuildingImageProvider>(),
          building,
          builtBuilding));
  gh.factoryParam<_i76.BuildingViewModel, _i73.Building, dynamic>(
      (_building, _) => _i76.BuildingViewModel(
          get<_i10.NavigationWrapper>(),
          get<_i59.BuildingChainProvider>(),
          get<_i77.ConstructedBuildingsProvider>(),
          get<_i14.SelectedColonizedStellarObjectProvider>(),
          get<_i75.BuildingImageProvider>(),
          get<_i68.StoredResourceProvider>(),
          get<_i71.BuildBuildingExecuter>(),
          get<_i9.EventService>(),
          get<_i7.ResourceHelper>(),
          _building));
  gh.singleton<_i13.AuthorizationTokenProvider>(
      _i13.AuthorizationTokenProvider());
  gh.singletonAsync<_i78.DeviceInfo>(() => _i78.DeviceInfo.instance());
  gh.singleton<_i9.EventService>(_i9.EventService());
  gh.singleton<_i16.Logger>(servicesModule.logger);
  gh.singleton<_i10.NavigationWrapper>(_i10.NavigationWrapper());
  gh.singleton<_i18.PlayerProvider>(_i18.PlayerProvider());
  gh.singleton<_i14.SelectedColonizedStellarObjectProvider>(
      _i14.SelectedColonizedStellarObjectProvider(get<_i18.PlayerProvider>()));
  gh.singleton<_i22.ServerConnection>(_i22.ServerConnection());
  gh.singleton<_i27.DialogHelper>(
      _i27.DialogHelper(get<_i10.NavigationWrapper>()));
  gh.singleton<_i66.StudiedResearchesProvider>(
      _i66.StudiedResearchesProvider(get<_i33.StudiedResearchRepository>()));
  gh.singleton<_i38.BuildingsProvider>(
      _i38.BuildingsProvider(get<_i36.BuildingRepository>()));
  gh.singleton<_i77.ConstructedBuildingsProvider>(
      _i77.ConstructedBuildingsProvider(get<_i39.BuiltBuildingRepository>()));
  gh.singleton<_i67.ResearchImageProvider>(
      _i67.ResearchImageProvider(get<_i21.ResearchRepository>()));
  gh.singleton<_i49.ResearchProvider>(
      _i49.ResearchProvider(get<_i21.ResearchRepository>()));
  gh.singleton<_i69.ResearchStudyProvider>(
      _i69.ResearchStudyProvider(get<_i23.ResearchStudyRepository>()));
  gh.singleton<_i56.ResourceProvider>(
      _i56.ResourceProvider(get<_i24.ResourceRepository>()));
  gh.singleton<_i52.ResourceSnapshotProvider>(
      _i52.ResourceSnapshotProvider(get<_i25.ResourceSnapshotRepository>()));
  gh.singleton<_i68.StoredResourceProvider>(_i68.StoredResourceProvider(
      get<_i9.EventService>(),
      get<_i52.ResourceSnapshotProvider>(),
      get<_i14.SelectedColonizedStellarObjectProvider>()));
  gh.singleton<_i59.BuildingChainProvider>(
      _i59.BuildingChainProvider(get<_i35.BuildingChainRepository>()));
  gh.singleton<_i61.BuildingHub>(_i61.BuildingHub(
      get<_i9.EventService>(),
      get<_i22.ServerConnection>(),
      get<_i12.HttpHeaderProvider>(),
      get<_i59.BuildingChainProvider>(),
      get<_i77.ConstructedBuildingsProvider>()));
  gh.singleton<_i75.BuildingImageProvider>(
      _i75.BuildingImageProvider(get<_i36.BuildingRepository>()));
  return get;
}

class _$ServicesModule extends _i79.ServicesModule {}
