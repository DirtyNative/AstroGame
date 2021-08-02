// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'player_dependent_technology_upgrade.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

PlayerDependentTechnologyUpgrade _$PlayerDependentTechnologyUpgradeFromJson(
    Map<String, dynamic> json) {
  return PlayerDependentTechnologyUpgrade()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..technologyId =
        const GuidConverter().fromJson(json['technologyId'] as String)
    ..startTime = DateTime.parse(json['startTime'] as String)
    ..endTime = DateTime.parse(json['endTime'] as String)
    ..hangfireJobId = json['hangfireJobId'] as String
    ..playerId = const GuidConverter().fromJson(json['playerId'] as String);
}

Map<String, dynamic> _$PlayerDependentTechnologyUpgradeToJson(
        PlayerDependentTechnologyUpgrade instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'technologyId': const GuidConverter().toJson(instance.technologyId),
      'startTime': instance.startTime.toIso8601String(),
      'endTime': instance.endTime.toIso8601String(),
      'hangfireJobId': instance.hangfireJobId,
      'playerId': const GuidConverter().toJson(instance.playerId),
    };
