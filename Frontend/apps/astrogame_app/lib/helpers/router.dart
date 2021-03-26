import 'package:astrogame_app/bags/show_planet_view_bag.dart';
import 'package:astrogame_app/communications/dtos/add_player_species_request.dart';
import 'package:astrogame_app/helpers/route_paths.dart';
import 'package:astrogame_app/views/login/login_view.dart';
import 'package:astrogame_app/views/perk_selection/perk_selection_view.dart';
import 'package:astrogame_app/views/planet/planet_view.dart';
import 'package:astrogame_app/views/species_selection/species_selection_view.dart';
import 'package:astrogame_app/views/start/start_view.dart';
import 'package:flutter/material.dart';

Route<dynamic> generateRoute(RouteSettings settings) {
  switch (settings.name) {
    case RoutePaths.LoginRoute:
      return MaterialPageRoute(builder: (_) => LoginView());

    case RoutePaths.SpeciesSelectionRoute:
      return MaterialPageRoute(builder: (_) => SpeciesSelectionView());

    case RoutePaths.PerkSelectionRoute:
      var requestDto = settings.arguments as AddPlayerSpeciesRequest;
      return MaterialPageRoute(builder: (_) => PerkSelectionView(requestDto));

    case RoutePaths.StartRoute:
      return MaterialPageRoute(builder: (_) => StartView());

    case RoutePaths.PlanetViewRoute:
      var bag = settings.arguments as ShowPlanetViewBag;
      return MaterialPageRoute(builder: (_) => PlanetView(bag.planet));
  }

  return MaterialPageRoute(
    builder: (_) => Scaffold(
      body: Center(
        child: Text('No path for ${settings.name}'),
      ),
    ),
  );
}
