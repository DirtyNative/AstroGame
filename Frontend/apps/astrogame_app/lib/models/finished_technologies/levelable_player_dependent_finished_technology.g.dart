// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'levelable_player_dependent_finished_technology.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

LevelablePlayerDependentFinishedTechnology
    _$LevelablePlayerDependentFinishedTechnologyFromJson(
        Map<String, dynamic> json) {
  return LevelablePlayerDependentFinishedTechnology()
    ..level = json['level'] as int
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..technologyId =
        const GuidConverter().fromJson(json['technologyId'] as String)
    ..playerId = const GuidConverter().fromJson(json['playerId'] as String);
}

Map<String, dynamic> _$LevelablePlayerDependentFinishedTechnologyToJson(
        LevelablePlayerDependentFinishedTechnology instance) =>
    <String, dynamic>{
      'level': instance.level,
      'id': const GuidConverter().toJson(instance.id),
      'technologyId': const GuidConverter().toJson(instance.technologyId),
      'playerId': const GuidConverter().toJson(instance.playerId),
    };
