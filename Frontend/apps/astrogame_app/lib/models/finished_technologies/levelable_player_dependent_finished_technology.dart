import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/finished_technologies/levelable_finished_technology.dart';
import 'player_dependent_finished_technology.dart';
import 'package:json_annotation/json_annotation.dart';

part 'levelable_player_dependent_finished_technology.g.dart';

@JsonSerializable()
@GuidConverter()
class LevelablePlayerDependentFinishedTechnology
    extends PlayerDependentFinishedTechnology with LevelableFinishedTechnology {
  LevelablePlayerDependentFinishedTechnology();

  factory LevelablePlayerDependentFinishedTechnology.fromJson(
          Map<String, dynamic> json) =>
      _$LevelablePlayerDependentFinishedTechnologyFromJson(json);
  Map<String, dynamic> toJson() =>
      _$LevelablePlayerDependentFinishedTechnologyToJson(this);
}
