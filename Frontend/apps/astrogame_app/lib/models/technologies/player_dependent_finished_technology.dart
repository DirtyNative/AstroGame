import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/technologies/finished_technology.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

part 'player_dependent_finished_technology.g.dart';

@GuidConverter()
@JsonSerializable()
class PlayerDependentFinishedTechnology extends FinishedTechnology {
  @JsonKey()
  Guid playerId;

  PlayerDependentFinishedTechnology();

  factory PlayerDependentFinishedTechnology.fromJson(
          Map<String, dynamic> json) =>
      _$PlayerDependentFinishedTechnologyFromJson(json);
  Map<String, dynamic> toJson() =>
      _$PlayerDependentFinishedTechnologyToJson(this);
}
