// GENERATED CODE - DO NOT MODIFY BY HAND

// **************************************************************************
// InjectableConfigGenerator
// **************************************************************************

import 'package:dio/dio.dart' as _i11;
import 'package:get_it/get_it.dart' as _i1;
import 'package:injectable/injectable.dart' as _i2;
import 'package:logger/logger.dart' as _i13;

import '../communications/hubs/building_hub.dart' as _i54;
import '../communications/interceptors/header_interceptor.dart' as _i3;
import '../communications/repositories/authorization_repository.dart' as _i37;
import '../communications/repositories/building_chain_repository.dart' as _i38;
import '../communications/repositories/building_repository.dart' as _i39;
import '../communications/repositories/finished_technology_repository.dart'
    as _i12;
import '../communications/repositories/image_respository.dart' as _i17;
import '../communications/repositories/perk_repository.dart' as _i19;
import '../communications/repositories/player_repository.dart' as _i22;
import '../communications/repositories/player_species_repository.dart' as _i23;
import '../communications/repositories/research_repository.dart' as _i24;
import '../communications/repositories/research_study_repository.dart' as _i25;
import '../communications/repositories/resource_repository.dart' as _i26;
import '../communications/repositories/resource_snapshot_repository.dart'
    as _i27;
import '../communications/repositories/solar_system_repository.dart' as _i30;
import '../communications/repositories/species_repository.dart' as _i31;
import '../communications/repositories/stellar_object_repository.dart' as _i34;
import '../communications/repositories/stored_resource_repository.dart' as _i35;
import '../communications/repositories/technology_repository.dart' as _i36;
import '../communications/server_connection.dart' as _i18;
import '../executers/build_building_executer.dart' as _i60;
import '../executers/fetch_solar_system_executer.dart' as _i42;
import '../executers/login_executer.dart' as _i55;
import '../executers/set_players_species_executer.dart' as _i28;
import '../helpers/dialog_helper.dart' as _i29;
import '../helpers/resource_helper.dart' as _i7;
import '../providers/authorization_token_provider.dart' as _i15;
import '../providers/building_chain_provider.dart' as _i52;
import '../providers/buildings_provider.dart' as _i41;
import '../providers/constructed_buildings_provider.dart' as _i63;
import '../providers/fulfilled_conditions_provider.dart' as _i64;
import '../providers/http_header_provider.dart' as _i14;
import '../providers/image_provider.dart' as _i33;
import '../providers/player_provider.dart' as _i21;
import '../providers/research_provider.dart' as _i47;
import '../providers/research_study_provider.dart' as _i65;
import '../providers/resource_provider.dart' as _i49;
import '../providers/resource_snapshot_provider.dart' as _i66;
import '../providers/selected_colonized_stellar_object_provider.dart' as _i16;
import '../providers/solar_systems_provider.dart' as _i44;
import '../providers/stored_resource_provider.dart' as _i58;
import '../providers/studied_researches_provider.dart' as _i62;
import '../providers/technologies_provider.dart' as _i67;
import '../services/event_service.dart' as _i9;
import '../services/hub_service.dart' as _i53;
import '../services/local_storage_service.dart' as _i56;
import '../services/navigation_wrapper.dart' as _i10;
import '../views/buildings/buildings_viewmodel.dart' as _i40;
import '../views/galaxy/galaxy_viewmodel.dart' as _i43;
import '../views/home/home_viewmodel.dart' as _i4;
import '../views/home/widgets/constructions_viewmodel.dart' as _i51;
import '../views/market/market_viewmodel.dart' as _i5;
import '../views/menus/menu_viewmodel.dart' as _i45;
import '../views/menus/player_colonies_viewmodel.dart' as _i20;
import '../views/menus/resource_viewmodel.dart' as _i57;
import '../views/register/register_viewmodel.dart' as _i6;
import '../views/researches/researches_viewmodel.dart' as _i46;
import '../views/resources/resources_viewmodel.dart' as _i48;
import '../views/solar_system/solar_system_viewmodel.dart' as _i8;
import '../views/species_selection/species_selection_viewmodel.dart' as _i32;
import '../views/splash/splash_viewmodel.dart' as _i59;
import '../views/start/start_viewmodel.dart' as _i50;
import 'device_info.dart' as _i61;
import 'services_module.dart' as _i68; // ignore_for_file: unnecessary_lambdas

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
  gh.factory<_i7.ResourceHelper>(() => _i7.ResourceHelper());
  gh.factory<_i8.SolarSystemViewModel>(() => _i8.SolarSystemViewModel(
      get<_i9.EventService>(), get<_i10.NavigationWrapper>()));
  gh.factory<_i11.Dio>(() => servicesModule.dio(get<_i3.HeaderInterceptor>()));
  gh.factory<_i12.FinishedTechnologyRepository>(() =>
      _i12.FinishedTechnologyRepository(get<_i11.Dio>(), get<_i13.Logger>()));
  gh.factory<_i14.HttpHeaderProvider>(() => _i14.HttpHeaderProvider(
      get<_i15.AuthorizationTokenProvider>(),
      get<_i16.SelectedColonizedStellarObjectProvider>()));
  gh.factory<_i17.ImageRepository>(() => _i17.ImageRepository(
      get<_i11.Dio>(),
      get<_i13.Logger>(),
      get<_i18.ServerConnection>(),
      get<_i14.HttpHeaderProvider>()));
  gh.factory<_i19.PerkRepository>(
      () => _i19.PerkRepository(get<_i11.Dio>(), get<_i13.Logger>()));
  gh.factory<_i20.PlayerColoniesViewModel>(
      () => _i20.PlayerColoniesViewModel(get<_i21.PlayerProvider>()));
  gh.factory<_i22.PlayerRepository>(
      () => _i22.PlayerRepository(get<_i11.Dio>(), get<_i13.Logger>()));
  gh.factory<_i23.PlayerSpeciesRepository>(
      () => _i23.PlayerSpeciesRepository(get<_i11.Dio>(), get<_i13.Logger>()));
  gh.factory<_i24.ResearchRepository>(() => _i24.ResearchRepository(
      get<_i11.Dio>(),
      get<_i13.Logger>(),
      get<_i18.ServerConnection>(),
      get<_i14.HttpHeaderProvider>()));
  gh.factory<_i25.ResearchStudyRepository>(
      () => _i25.ResearchStudyRepository(get<_i11.Dio>(), get<_i13.Logger>()));
  gh.factory<_i26.ResourceRepository>(
      () => _i26.ResourceRepository(get<_i11.Dio>(), get<_i13.Logger>()));
  gh.factory<_i27.ResourceSnapshotRepository>(() =>
      _i27.ResourceSnapshotRepository(get<_i11.Dio>(), get<_i13.Logger>()));
  gh.factory<_i28.SetPlayersSpeciesExecuter>(() =>
      _i28.SetPlayersSpeciesExecuter(
          get<_i22.PlayerRepository>(),
          get<_i23.PlayerSpeciesRepository>(),
          get<_i21.PlayerProvider>(),
          get<_i29.DialogHelper>(),
          get<_i10.NavigationWrapper>()));
  gh.factory<_i30.SolarSystemRepository>(
      () => _i30.SolarSystemRepository(get<_i11.Dio>(), get<_i13.Logger>()));
  gh.factory<_i31.SpeciesRepository>(
      () => _i31.SpeciesRepository(get<_i11.Dio>(), get<_i13.Logger>()));
  gh.factory<_i32.SpeciesSelectionViewModel>(() =>
      _i32.SpeciesSelectionViewModel(get<_i10.NavigationWrapper>(),
          get<_i31.SpeciesRepository>(), get<_i33.SpeciesImageProvider>()));
  gh.factory<_i34.StellarObjectRepository>(() => _i34.StellarObjectRepository(
      get<_i11.Dio>(), get<_i13.Logger>(), get<_i18.ServerConnection>()));
  gh.factory<_i35.StoredResourceRepository>(
      () => _i35.StoredResourceRepository(get<_i11.Dio>(), get<_i13.Logger>()));
  gh.factory<_i36.TechnologyRepository>(
      () => _i36.TechnologyRepository(get<_i11.Dio>(), get<_i13.Logger>()));
  gh.factory<_i37.AuthorizationRepository>(
      () => _i37.AuthorizationRepository(get<_i11.Dio>(), get<_i13.Logger>()));
  gh.factory<_i38.BuildingChainRepository>(
      () => _i38.BuildingChainRepository(get<_i11.Dio>(), get<_i13.Logger>()));
  gh.factory<_i39.BuildingRepository>(() => _i39.BuildingRepository(
      get<_i11.Dio>(),
      get<_i13.Logger>(),
      get<_i18.ServerConnection>(),
      get<_i14.HttpHeaderProvider>()));
  gh.factory<_i40.BuildingsViewModel>(
      () => _i40.BuildingsViewModel(get<_i41.BuildingsProvider>()));
  gh.factory<_i42.FetchSolarSystemExecuter>(() => _i42.FetchSolarSystemExecuter(
      get<_i29.DialogHelper>(), get<_i30.SolarSystemRepository>()));
  gh.factory<_i43.GalaxyViewModel>(
      () => _i43.GalaxyViewModel(get<_i44.SolarSystemsProvider>()));
  gh.factory<_i45.MenuViewModel>(() => _i45.MenuViewModel(
      get<_i10.NavigationWrapper>(),
      get<_i21.PlayerProvider>(),
      get<_i33.SpeciesImageProvider>()));
  gh.factory<_i46.ResearchesViewModel>(
      () => _i46.ResearchesViewModel(get<_i47.ResearchProvider>()));
  gh.factory<_i48.ResourcesViewModel>(
      () => _i48.ResourcesViewModel(get<_i49.ResourceProvider>()));
  gh.factory<_i50.StartViewModel>(() => _i50.StartViewModel(
      get<_i42.FetchSolarSystemExecuter>(), get<_i9.EventService>()));
  gh.factory<_i51.ConstructionsViewModel>(() => _i51.ConstructionsViewModel(
      get<_i52.BuildingChainProvider>(), get<_i9.EventService>()));
  gh.factory<_i53.HubService>(() => _i53.HubService(get<_i54.BuildingHub>()));
  gh.factory<_i55.LoginExecuter>(() => _i55.LoginExecuter(
      get<_i37.AuthorizationRepository>(),
      get<_i22.PlayerRepository>(),
      get<_i15.AuthorizationTokenProvider>(),
      get<_i21.PlayerProvider>(),
      get<_i29.DialogHelper>(),
      get<_i10.NavigationWrapper>(),
      get<_i53.HubService>(),
      get<_i56.LocalStorageService>()));
  gh.factory<_i57.ResourceViewModel>(() => _i57.ResourceViewModel(
      get<_i9.EventService>(),
      get<_i49.ResourceProvider>(),
      get<_i58.StoredResourceProvider>()));
  gh.factory<_i59.SplashViewModel>(() => _i59.SplashViewModel(
      get<_i53.HubService>(),
      get<_i56.LocalStorageService>(),
      get<_i10.NavigationWrapper>(),
      get<_i21.PlayerProvider>(),
      get<_i22.PlayerRepository>(),
      get<_i15.AuthorizationTokenProvider>()));
  gh.factory<_i60.BuildBuildingExecuter>(() => _i60.BuildBuildingExecuter(
      get<_i9.EventService>(),
      get<_i29.DialogHelper>(),
      get<_i39.BuildingRepository>(),
      get<_i52.BuildingChainProvider>(),
      get<_i58.StoredResourceProvider>()));
  gh.singleton<_i15.AuthorizationTokenProvider>(
      _i15.AuthorizationTokenProvider());
  gh.singletonAsync<_i61.DeviceInfo>(() => _i61.DeviceInfo.instance());
  gh.singleton<_i9.EventService>(_i9.EventService());
  gh.singleton<_i56.LocalStorageService>(_i56.LocalStorageService());
  gh.singleton<_i13.Logger>(servicesModule.logger);
  gh.singleton<_i10.NavigationWrapper>(_i10.NavigationWrapper());
  gh.singleton<_i21.PlayerProvider>(_i21.PlayerProvider());
  gh.singleton<_i16.SelectedColonizedStellarObjectProvider>(
      _i16.SelectedColonizedStellarObjectProvider(get<_i21.PlayerProvider>()));
  gh.singleton<_i18.ServerConnection>(_i18.ServerConnection());
  gh.singleton<_i29.DialogHelper>(
      _i29.DialogHelper(get<_i10.NavigationWrapper>()));
  gh.singleton<_i33.ResearchImageProvider>(
      _i33.ResearchImageProvider(get<_i17.ImageRepository>()));
  gh.singleton<_i44.SolarSystemsProvider>(
      _i44.SolarSystemsProvider(get<_i30.SolarSystemRepository>()));
  gh.singleton<_i33.SpeciesImageProvider>(
      _i33.SpeciesImageProvider(get<_i17.ImageRepository>()));
  gh.singleton<_i33.StellarObjectImageProvider>(
      _i33.StellarObjectImageProvider(get<_i17.ImageRepository>()));
  gh.singleton<_i62.StudiedResearchesProvider>(
      _i62.StudiedResearchesProvider(get<_i12.FinishedTechnologyRepository>()));
  gh.singleton<_i33.BuildingImageProvider>(
      _i33.BuildingImageProvider(get<_i17.ImageRepository>()));
  gh.singleton<_i41.BuildingsProvider>(
      _i41.BuildingsProvider(get<_i39.BuildingRepository>()));
  gh.singleton<_i63.ConstructedBuildingsProvider>(
      _i63.ConstructedBuildingsProvider(
          get<_i12.FinishedTechnologyRepository>()));
  gh.singleton<_i64.FulfilledConditionsProvider>(
      _i64.FulfilledConditionsProvider(get<_i36.TechnologyRepository>()));
  gh.singleton<_i47.ResearchProvider>(
      _i47.ResearchProvider(get<_i24.ResearchRepository>()));
  gh.singleton<_i65.ResearchStudyProvider>(
      _i65.ResearchStudyProvider(get<_i25.ResearchStudyRepository>()));
  gh.singleton<_i49.ResourceProvider>(
      _i49.ResourceProvider(get<_i26.ResourceRepository>()));
  gh.singleton<_i66.ResourceSnapshotProvider>(
      _i66.ResourceSnapshotProvider(get<_i27.ResourceSnapshotRepository>()));
  gh.singleton<_i58.StoredResourceProvider>(_i58.StoredResourceProvider(
      get<_i9.EventService>(),
      get<_i66.ResourceSnapshotProvider>(),
      get<_i16.SelectedColonizedStellarObjectProvider>()));
  gh.singleton<_i67.TechnologiesProvider>(
      _i67.TechnologiesProvider(get<_i36.TechnologyRepository>()));
  gh.singleton<_i52.BuildingChainProvider>(
      _i52.BuildingChainProvider(get<_i38.BuildingChainRepository>()));
  gh.singleton<_i54.BuildingHub>(_i54.BuildingHub(
      get<_i9.EventService>(),
      get<_i18.ServerConnection>(),
      get<_i14.HttpHeaderProvider>(),
      get<_i52.BuildingChainProvider>(),
      get<_i63.ConstructedBuildingsProvider>()));
  return get;
}

class _$ServicesModule extends _i68.ServicesModule {}
