import 'package:astrogame_app/bags/show_planet_view_bag.dart';
import 'package:astrogame_app/communications/dtos/add_player_species_request.dart';
import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/helpers/route_paths.dart';
import 'package:astrogame_app/views/building_detail/bags/building_detail_bag.dart';
import 'package:astrogame_app/views/building_detail/building_detail_view.dart';
import 'package:astrogame_app/views/buildings/buildings_view.dart';
import 'package:astrogame_app/views/home/home_view.dart';
import 'package:astrogame_app/views/login/login_view.dart';
import 'package:astrogame_app/views/market/market_view.dart';
import 'package:astrogame_app/views/perk_selection/perk_selection_view.dart';
import 'package:astrogame_app/views/planet/planet_view.dart';
import 'package:astrogame_app/views/register/register_view.dart';
import 'package:astrogame_app/views/resources/resources_view.dart';
import 'package:astrogame_app/views/shells/main_shell.dart';
import 'package:astrogame_app/views/species_selection/species_selection_view.dart';
import 'package:astrogame_app/views/start/start_view.dart';
import 'package:flutter/material.dart';

Route<dynamic> generateRoute(RouteSettings settings) {
  switch (settings.name) {

    // Shells
    case RoutePaths.MainShellRoute:
      return MaterialPageRoute(builder: (_) => MainShell(ServiceLocator.get()));

    // Login
    case RoutePaths.LoginRoute:
      return MaterialPageRoute(builder: (_) => LoginView());

    case RoutePaths.RegisterRoute:
      return MaterialPageRoute(builder: (_) => RegisterView());

    case RoutePaths.SpeciesSelectionRoute:
      return MaterialPageRoute(builder: (_) => SpeciesSelectionView());

    case RoutePaths.PerkSelectionRoute:
      var requestDto = settings.arguments as AddPlayerSpeciesRequest;
      return MaterialPageRoute(builder: (_) => PerkSelectionView(requestDto));

    // Menu
    case RoutePaths.HomeRoute:
      return MaterialPageRoute(builder: (_) => HomeView());

    case RoutePaths.SystemViewRoute:
      return MaterialPageRoute(builder: (_) => StartView());

    case RoutePaths.BuildingsRoute:
      return MaterialPageRoute(builder: (_) => BuildingsView());

    case RoutePaths.BuildingDetailsRoute:
      var bag = settings.arguments as BuildingDetailBag;
      return MaterialPageRoute(builder: (_) => BuildingDetailView(bag.building, bag.builtBuilding));

    case RoutePaths.PlanetViewRoute:
      var bag = settings.arguments as ShowPlanetViewBag;
      return MaterialPageRoute(builder: (_) => PlanetView(bag.planet));

    case RoutePaths.ResourcesRoute:
      return MaterialPageRoute(builder: (_) => ResourcesView());

    case RoutePaths.MarketRoute:
      return MaterialPageRoute(builder: (_) => MarketView());

    // Common
  }

  return MaterialPageRoute(
    builder: (_) => Scaffold(
      body: Center(
        child: Text('No path for ${settings.name}'),
      ),
    ),
  );
}
