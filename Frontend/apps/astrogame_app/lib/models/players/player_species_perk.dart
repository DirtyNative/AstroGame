import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/players/perk.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

part 'player_species_perk.g.dart';

@GuidConverter()
@JsonSerializable()
class PlayerSpeciesPerk {
  Guid id;
  Guid playerSpeciesId;
  Guid perkId;

  Perk perk;

  PlayerSpeciesPerk();

  factory PlayerSpeciesPerk.fromJson(Map<String, dynamic> json) =>
      _$PlayerSpeciesPerkFromJson(json);
  Map<String, dynamic> toJson() => _$PlayerSpeciesPerkToJson(this);
}
