// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'add_player_species_perk_request.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

AddPlayerSpeciesPerkRequest _$AddPlayerSpeciesPerkRequestFromJson(
    Map<String, dynamic> json) {
  return AddPlayerSpeciesPerkRequest()
    ..perkId = const GuidConverter().fromJson(json['perkId'] as String);
}

Map<String, dynamic> _$AddPlayerSpeciesPerkRequestToJson(
        AddPlayerSpeciesPerkRequest instance) =>
    <String, dynamic>{
      'perkId': const GuidConverter().toJson(instance.perkId),
    };
