import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/common/guid.dart';

import 'package:json_annotation/json_annotation.dart';

part 'add_player_species_perk_request.g.dart';

@GuidConverter()
@JsonSerializable()
class AddPlayerSpeciesPerkRequest {
  Guid perkId;

  AddPlayerSpeciesPerkRequest(this.perkId);

  factory AddPlayerSpeciesPerkRequest.fromJson(Map<String, dynamic> json) =>
      _$AddPlayerSpeciesPerkRequestFromJson(json);
  Map<String, dynamic> toJson() => _$AddPlayerSpeciesPerkRequestToJson(this);
}
