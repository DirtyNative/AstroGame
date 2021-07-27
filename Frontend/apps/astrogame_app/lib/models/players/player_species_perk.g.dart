// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'player_species_perk.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

PlayerSpeciesPerk _$PlayerSpeciesPerkFromJson(Map<String, dynamic> json) {
  return PlayerSpeciesPerk()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..playerSpeciesId =
        const GuidConverter().fromJson(json['playerSpeciesId'] as String)
    ..perkId = const GuidConverter().fromJson(json['perkId'] as String)
    ..perk = Perk.fromJson(json['perk'] as Map<String, dynamic>);
}

Map<String, dynamic> _$PlayerSpeciesPerkToJson(PlayerSpeciesPerk instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'playerSpeciesId': const GuidConverter().toJson(instance.playerSpeciesId),
      'perkId': const GuidConverter().toJson(instance.perkId),
      'perk': instance.perk,
    };
