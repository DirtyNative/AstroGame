// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'player_dependent_finished_technology.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

PlayerDependentFinishedTechnology _$PlayerDependentFinishedTechnologyFromJson(
    Map<String, dynamic> json) {
  return PlayerDependentFinishedTechnology()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..technologyId =
        const GuidConverter().fromJson(json['technologyId'] as String)
    ..level = json['level'] as int
    ..playerId = const GuidConverter().fromJson(json['playerId'] as String);
}

Map<String, dynamic> _$PlayerDependentFinishedTechnologyToJson(
        PlayerDependentFinishedTechnology instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'technologyId': const GuidConverter().toJson(instance.technologyId),
      'level': instance.level,
      'playerId': const GuidConverter().toJson(instance.playerId),
    };
