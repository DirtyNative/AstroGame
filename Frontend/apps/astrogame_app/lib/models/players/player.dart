import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/common/guid.dart';

import 'package:json_annotation/json_annotation.dart';

import 'colonized_stellar_object.dart';
import 'player_species.dart';

part 'player.g.dart';

@GuidConverter()
@JsonSerializable()
class Player {
  late Guid id;
  late String username;
  late Guid playerSpeciesId;
  late List<ColonizedStellarObject> colonizedObjects;
  late PlayerSpecies? playerSpecies;

  Player();

  factory Player.fromJson(Map<String, dynamic> json) => _$PlayerFromJson(json);
  Map<String, dynamic> toJson() => _$PlayerToJson(this);
}
