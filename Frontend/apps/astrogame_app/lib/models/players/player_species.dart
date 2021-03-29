import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/enums/planet_type.dart';
import 'package:astrogame_app/models/players/player_species_perk.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

import 'species.dart';

part 'player_species.g.dart';

@GuidConverter()
@JsonSerializable()
class PlayerSpecies {
  Guid id;
  Guid playerId;
  Guid speciesId;
  String empireName;
  PlanetType preferredPlanetType;

  List<PlayerSpeciesPerk> perks;

  Species species;

  PlayerSpecies();

  factory PlayerSpecies.fromJson(Map<String, dynamic> json) =>
      _$PlayerSpeciesFromJson(json);
  Map<String, dynamic> toJson() => _$PlayerSpeciesToJson(this);
}
