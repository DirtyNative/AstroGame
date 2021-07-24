import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/finished_technologies/one_time_finished_technology.dart';
import 'player_dependent_finished_technology.dart';
import 'package:json_annotation/json_annotation.dart';

part 'one_time_player_dependent_finished_technology.g.dart';

@JsonSerializable()
@GuidConverter()
class OneTimePlayerDependentFinishedTechnology
    extends PlayerDependentFinishedTechnology with OneTimeFinishedTechnology {
  OneTimePlayerDependentFinishedTechnology();

  factory OneTimePlayerDependentFinishedTechnology.fromJson(
          Map<String, dynamic> json) =>
      _$OneTimePlayerDependentFinishedTechnologyFromJson(json);
  Map<String, dynamic> toJson() =>
      _$OneTimePlayerDependentFinishedTechnologyToJson(this);
}
