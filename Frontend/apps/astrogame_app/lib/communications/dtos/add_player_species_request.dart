import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/communications/dtos/add_player_species_perk_request.dart';
import 'package:astrogame_app/models/common/guid.dart';
import 'package:astrogame_app/models/enums/planet_type.dart';

import 'package:json_annotation/json_annotation.dart';

part 'add_player_species_request.g.dart';

@GuidConverter()
@JsonSerializable()
class AddPlayerSpeciesRequest {
  Guid speciesId;
  String empireName;
  PlanetType preferredPlanetType;
  List<AddPlayerSpeciesPerkRequest> perks = [];

  AddPlayerSpeciesRequest(
      this.speciesId, this.empireName, this.preferredPlanetType, this.perks);

  factory AddPlayerSpeciesRequest.fromJson(Map<String, dynamic> json) =>
      _$AddPlayerSpeciesRequestFromJson(json);
  Map<String, dynamic> toJson() => _$AddPlayerSpeciesRequestToJson(this);
}
